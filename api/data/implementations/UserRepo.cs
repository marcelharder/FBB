
namespace FBB.data.implementations;
public class UserRepo : IUsers
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly IGeneral _gen;
    public UserRepo(
        IGeneral gen,
        UserManager<AppUser> userManager, 
        ApplicationDbContext context, 
        IMapper mapper)
    {
        _userManager = userManager;
        _context = context;
        _mapper = mapper;
        _gen = gen;

    }

   

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public async Task<List<UserDto>> GetAllUsers()
    {
       UserDto ud;
       var result = new List<UserDto>();
       var l = new List<AppUser>();
       l = await _userManager.Users.ToListAsync();
       foreach(AppUser us in l){
         us.Country = await _gen.GetCountryNameFromCode(us.Country);
         ud = _mapper.Map<UserDto>(us);
         result.Add(ud);
       }

       return result;
    }

    public async Task<UserDto?> GetSpecificUser(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        user.Country = await _gen.GetCountryNameFromCode(user.Country);

      
        return _mapper.Map<UserDto>(user);
    }

    

    public async Task<AppUser?> GetUserByMail(string email)
    {
        if (email != null)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null) { return user; }
        }

        return null;
    }

    

     public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    public void Update(AppUser p)
    {
        _context.Update(p);
    }

  
    public async Task<bool> UpdatePayment(DateTime d, int id)
        {
           var help = false;
           var user = await GetSpecificUser(id);
           user!.PaidTill = d;
           _context.Update(user);
           if(await _context.SaveChangesAsync() > 0){ help = true;}
           return help;
        }

   

   
}