using TaskManagement.Dto;
using TaskManagement.Models;

namespace TaskManagement.Interfaces
{
    public interface IUserService
    {
        Task<bool> UpsertUser(UserDto data);
        Task<IList<CommonOutputDto>> GetAllUser();
        Task<UserDto> GetUserById(Guid UserID);
    }
}
