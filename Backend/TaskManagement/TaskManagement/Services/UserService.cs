using TaskManagement.Dto;
using TaskManagement.Infrastructure;
using TaskManagement.Interfaces;
using TaskManagement.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Bcrypt=BCrypt.Net.BCrypt;

namespace TaskManagement.Services
{
    public class UserService:IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<CommonOutputDto>> GetAllUser()
        {
            var result=new List<CommonOutputDto>();

            result = (from u in await _context.Users.ToListAsync()
                     select new CommonOutputDto()
                     {
                         Id = u.UserId,
                         Name = u.Name,
                     }).ToList();

            return result;
        }

        public async Task<UserDto> GetUserById(Guid UserID)
        {
            var data = await _context.Users.FirstOrDefaultAsync(x => x.UserId == UserID);
            var result = new UserDto()
            {
                UserId = data.UserId,
                Email = data.Email,
                UserTypeId = data.UserTypeId,
                ManagerId = data.ManagerId,
                Name = data.Name
            };
            return result;
        }

        public async Task<bool> UpsertUser(UserDto data)
        {
            try
            {
                var result = false;
                var query = _context.Users.Where(x => x.Email == data.Email);
                var countUser = await query.CountAsync();

                if (countUser <= 0)
                {
                    var user = new User()
                    {
                        Name = data.Name,
                        Email = data.Email.ToLower(),
                        Password =  Bcrypt.HashPassword(data.Password),
                        UserTypeId = data.UserTypeId
                    };
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    result = true;
                }
                else
                {
                    var user = await query.FirstOrDefaultAsync();
                    if (user == null)
                    {
                        user.UpdatedOn= DateTime.Now;
                        user.Name= data.Name;
                        user.UserTypeId = data.UserTypeId;
                        user.ManagerId = data.ManagerId;
                        user.Password= Bcrypt.HashPassword(data.Password);
                        _context.Users.Update(user);
                        await _context.SaveChangesAsync();
                        result= true;
                    }
                }
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

        
    }
}
