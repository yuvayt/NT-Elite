using StudentAPI.Models.DTO;
using StudentAPI.Models.Entities;

namespace StudentAPI.Services.Interfaces
{
    public interface IUserService
    {
        Tokens Authenticate(User loginModel);
    }
}