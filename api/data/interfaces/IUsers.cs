using FBB.data.models;

namespace FBB.data.interfaces;

public interface IUsers
{
    Task<List<UserDto>> GetAllUsers();
    
    Task<AppUser?> GetUserByMail(string email);

    Task<AppUser?> GetUserByName(string name);

    Task<AppUser?> GetUserById(string name);
    Task<bool> UpdatePayment(DateTime d, int id);
    Task<bool> SaveAll();
    void Update(AppUser p);
    void Delete<T>(T entity)
        where T : class;
    Task<UserDto?> GetSpecificUser(int id);
    
    
}
