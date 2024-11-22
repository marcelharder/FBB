namespace FBB.data.interfaces;

public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }