namespace api.Controllers;

public class AccountController : BaseApiController
{

    private readonly ITokenService _ts;
    private readonly UserManager<AppUser> _manager;
    private readonly SignInManager<AppUser> _signIn;
    private readonly IMapper _mapper;

    public AccountController(IMapper mapper,
        ITokenService ts,
         UserManager<AppUser> manager,
        SignInManager<AppUser> signIn)
    {
        _mapper = mapper;
        _manager = manager;
        _signIn = signIn;
        _ts = ts;
     

    }

    [HttpGet("checkIfUserExists/{email}")]
    public async Task<int> Userexists(string email)
    {
        var result = 0;
        var user = await _manager.Users.FirstOrDefaultAsync(x => x.Email == email);
        if (user != null) { result = 1; }
        return result;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(UserForRegisterDto registerDto)
    {
        var user = await _manager.Users.SingleOrDefaultAsync(x => x.UserName == registerDto.UserName.ToLower());
        if (user != null) { return BadRequest("User already exists ..."); }
        user = _mapper.Map<AppUser>(registerDto);
        user.Created = DateTime.Now;
        user.PaidTill = DateTime.Now.AddDays(90);
        user.Mobile = registerDto.Mobile;
        user.Email = registerDto.Email;
        user.PhotoUrl = "../../assets/user.jpg";

        var result = await _manager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded) { return BadRequest(result.Errors); }

        var roleResult = await _manager.AddToRoleAsync(user, "Surgery");
        if (!roleResult.Succeeded) { return BadRequest(roleResult.Errors); }

        return new UserDto
        {
            UserName = user.UserName,
            PhotoUrl = user.PhotoUrl,
            Email = user.Email,
            Mobile = user.Mobile,
            Token = await _ts.CreateToken(user),
            Id = user.Id,
            KnownAs = user.KnownAs,
            PaidTill = user.PaidTill,
            Country = user.Country
        };
    }



    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(UserForLoginDto ufl)
    {
        var user = await _manager.Users.SingleOrDefaultAsync(x => x.UserName == ufl.UserName.ToLower());
        if (user == null) return Unauthorized();

        var result = await _signIn.CheckPasswordSignInAsync(user, ufl.Password, false);
        if (!result.Succeeded) return Unauthorized();


        return new UserDto
        {
            UserName = user.UserName!,
            PhotoUrl="",
            KnownAs = user.KnownAs,
            Email = "",
            Token = await _ts.CreateToken(user),
            Id = user.Id,
            PaidTill = user.PaidTill,
            Country = user.Country
        };
    }

    [HttpPut("changePassword")]
    public async Task<IActionResult> ChangePwd([FromBody] ChangePasswordDto ufl)
    {
        var user = await _manager.FindByEmailAsync(ufl.Email);
        if (user == null)
            return BadRequest("Invalid Request");

        var resultp = await _signIn.CheckPasswordSignInAsync(user, ufl.CurrentPassword, false);
        if (!resultp.Succeeded) return BadRequest("Pls use correct password ...");

        var result = await _manager.ChangePasswordAsync(user, ufl.CurrentPassword, ufl.Password);
        if (!result.Succeeded) return BadRequest("Changing password failed ...");

        return Ok("Password changed");
    }

  



}
