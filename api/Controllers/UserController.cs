namespace api.Controllers;

[Authorize]
public class UserController : BaseApiController
{
    private readonly IUsers _user;

    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _manager;
    private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
    private readonly Cloudinary _cloudinary;

    public UserController(
        UserManager<AppUser> manager,
        IUsers user,
        IMapper mapper,
        IOptions<CloudinarySettings> cloudinaryConfig
    )
    {
        _user = user;
        _mapper = mapper;
        _manager = manager;
        _cloudinaryConfig = cloudinaryConfig;
        Account acc = new Account(
            _cloudinaryConfig.Value.CloudName,
            _cloudinaryConfig.Value.ApiKey,
            _cloudinaryConfig.Value.ApiSecret
        );
        _cloudinary = new Cloudinary(acc);
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
    public async Task<IActionResult> AddPhotoForUser( int id, [FromForm] PhotoForCreationDto photoDto )
    {
        var user = await _manager.Users.SingleOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            return BadRequest("Referrer not available now");
        }

        var file = photoDto.File;
        var uploadResult = new ImageUploadResult();
        if (file.Length > 0)
        {
            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.Name, stream),
                    Transformation = new Transformation()
                        .Width(500)
                        .Height(500)
                        .Crop("fill")
                        .Gravity("face")
                };
                uploadResult = _cloudinary.Upload(uploadParams);
            }
            user.PhotoUrl = uploadResult?.SecureUrl?.AbsoluteUri;

            if (await _user.SaveAll())
            {
                UserDto ufr = _mapper.Map<AppUser, UserDto>(user);
                return CreatedAtRoute("GetUser", new { id = user.Id }, ufr);
            }
        }
        return BadRequest("Could not find photo to upload...");
    }

    [HttpPost("addUser")]
    public async Task<IActionResult> addUser(UserForRegisterDto ufr)
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
