using entity.service.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace entity.service
{
    public interface IUserService
    {
        Task<User> GetUser(Guid id);
        Task<IList<User>> GetUsers();

        Task<User> AddUser(User user);
        Task<IList<User>> AddUsers(IList<User> users);

        Task<User> UpdateUser(User user);
        Task<IList<User>> UpdateUsers(IList<User> users);

        Task<User> DeleteUser(Guid id);
        Task<IList<User>> DeleteUsers(IList<Guid> ids);
    }
}
