using System.Text.Json;
using FBB.data.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FBB.data;

public class Seed
{
    public static async Task SeedUsers(
        UserManager<AppUser> manager,
        RoleManager<AppRole> roleManager
    )
    {
        if (await manager.Users.AnyAsync())
            return;
        var userData = await System.IO.File.ReadAllTextAsync("data/seed/UserSeedData.json");
        var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
        if (users == null)
            return;

        var roles = new List<AppRole>
        {
            new AppRole { Name = "Surgery" },
            new AppRole { Name = "Moderator" },
            new AppRole { Name = "Sponsor" },
            new AppRole { Name = "Refcard" },
            new AppRole { Name = "Admin" },
            new AppRole { Name = "Cardiologist" },
            new AppRole { Name = "Chef" }
        };
        foreach (var role in roles)
        {
            await roleManager.CreateAsync(role);
        }
        foreach (AppUser ap in users)
        {
            ap.UserName = ap.UserName.ToLower();
            await manager.CreateAsync(ap, "Pa$$w0rd");
            await manager.AddToRoleAsync(ap, "Surgery");
        }

        var admin = new AppUser
        {
            UserName = "admin@gfancy.nl",
            Email = "admin@gfancy.nl",
            Gender = "male",
            KnownAs = "Administrator",
            PaidTill = new DateTime().AddYears(2250),
            Country = "31"
        };
        await manager.CreateAsync(admin, "Pa$$w0rd");
        await manager.AddToRoleAsync(admin, "Admin");
    }

   
     public static async Task SeedCaseReports(ApplicationDbContext context)
    {
        if (await context.CaseReports.AnyAsync())
            return;
        var catData = await System.IO.File.ReadAllTextAsync("data/seed/CaseReportSeed.json");
        var categories = JsonSerializer.Deserialize<List<CaseReport>>(catData);

        if (categories != null)
        {
            foreach (CaseReport rep in categories)
            {
                // save CaseReport to database
                context.CaseReports.Add(rep);
                await context.SaveChangesAsync();
            }
            
        }
    }
/*
    public static async Task SeedImages(ApplicationDbContext context, IImage image)
    {
        var counter = 0;
        var catList = new List<Category>();
        ImageDto test;

        if (await context.Images.AnyAsync())
            return;

        catList = await image.getCategories();

        if (catList != null)
        {
            for (int x = 1; x < catList.Count; x++)
            {
                if (catList[x].Number_of_images != 0)
                {
                    counter += (int)catList[x].Number_of_images;
                }
                string? url = catList[x].Name + "/" + x.ToString() + ".jpg";

                test = new ImageDto
                {
                    Id = counter.ToString(),
                    ImageUrl = url,
                    YearTaken = 1995,
                    Location = "",
                    Familie = "",
                    Category = catList[x].Id,
                    Series = "",
                    Spare1 = "",
                    Spare2 = "",
                    Spare3 = "",
                };
                await image.addImage(test);

                //addImage(catList[x],counter,url,_dapper);
            }
        }
    }

   */
 
 }
