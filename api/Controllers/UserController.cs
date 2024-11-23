using System.Security.Claims;

namespace api.Controllers;

[Authorize]
public class UserController : BaseApiController
{
    private readonly IUsers _user;

    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _manager;
    private readonly IPhotoService _photo;

    public UserController(
        UserManager<AppUser> manager,
        IUsers user,
        IPhotoService photo,
        IMapper mapper
    )
    {
        _user = user;
        _photo = photo;
        _mapper = mapper;
        _manager = manager;
    }

    [HttpGet]
    [Route("getAllUsers")]
    public async Task<ActionResult> GetAllUsers()
    {
        var allUsers = await _user.GetAllUsers();
        return Ok(allUsers);
    }

    [HttpGet]
    [Route("getSpecificUser/{id}", Name = "GetUser")]
    public async Task<ActionResult> GetSpecificUser(int id)
    {
        var spUser = await _user.GetSpecificUser(id);
        return Ok(spUser);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(UserForUpdateDto up, int id)
    {
        var user = await _manager.Users.SingleOrDefaultAsync(x => x.Id == id);
        if (user != null)
        {
            var userupdated = _mapper.Map<UserForUpdateDto, AppUser>(up, user);
            _user.Update(userupdated);
        }
        if (await _user.SaveAll())
            return NoContent();
        throw new Exception($"Updating user {up.Id} failed on save");
    }

    [HttpPost("addUserPhoto/{id}")]
    public async Task<IActionResult> AddPhotoForUser(IFormFile file, int id)
    {
        var user = await _manager.Users.SingleOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            return BadRequest("User cant be found ??");
        }

        var result = await _photo.AddPhotoAsync(file);
        if (result.Error != null)
        {
            return BadRequest(result.Error.Message);
        }
        user.PhotoUrl = result.SecureUrl?.AbsoluteUri;
        if (await _user.SaveAll())
        {
            UserDto ufr = _mapper.Map<AppUser, UserDto>(user);
            return CreatedAtRoute("GetUser", new { id = user.Id }, ufr);
        }

        return BadRequest();
    }

    [HttpPost("addUser")]
    public async Task<IActionResult> AddUser(UserForRegisterDto ufr)
    {
        var user = await _manager.Users.SingleOrDefaultAsync(x =>
            x.UserName == ufr.UserName.ToLower()
        );
        if (user != null)
        {
            return BadRequest("User already exists ...");
        }

        user = new AppUser
        {
            UserName = ufr.UserName.ToLower(),
            Country = ufr.Country,
            KnownAs = ufr.KnownAs,
            Created = DateTime.Now,
            LastActive = DateTime.Now,
            PaidTill = DateTime.Now.AddDays(30),
            Email = ufr.UserName.ToLower(),
            Gender = "Male",
            Mobile = ufr.Mobile,
            Active = ufr.Active,
            PhotoUrl = ""
        };

        var result = await _manager.CreateAsync(user, ufr.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        var roleResult = await _manager.AddToRoleAsync(user, "Surgery");
        if (!roleResult.Succeeded)
        {
            return BadRequest(roleResult.Errors);
        }

        UserDto ufre = _mapper.Map<UserDto>(user);
        return CreatedAtRoute("GetUser", new { id = user.Id }, ufre);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveUser(int id)
    {
        var userdto = await _manager.Users.SingleOrDefaultAsync(x => x.Id == id);
        var user = _mapper.Map<AppUser>(userdto);
        _user.Delete(user);
        if (await _user.SaveAll())
            return Ok("User deleted ...");
        return BadRequest("Deleting failed ...");
    }

    /*  [HttpPost]
 
     [HttpDelete] */
}
