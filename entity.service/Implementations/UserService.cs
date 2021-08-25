using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using entity.data;
using entity.service.model;
using Entities = entity.data.Entity;

namespace entity.service.Implementations
{
    internal class UserService : ServiceBase<User, Entities.User>, IUserService
    {
        protected override string[] DefaultIncludes => new string[]
        {
            "Jobs"
        };

        public UserService(IMapper mapper, tododbContext db) : base(mapper, db)
        {
        }

        public async Task<User> GetUser(Guid id)
        {
            return await Single(x => x.Id == id);
        }

        public async Task<IList<User>> GetUsers()
        {
            return await Query();
        }

        public async Task<User> AddUser(User user)
        {
            var result = await base.Add(user);
            return result ? await base.Single(x => x.Id == user.Id) : null;
        }

        public async Task<IList<User>> AddUsers(IList<User> users)
        {
            var result = new List<User>();

            foreach (var user in users)
            {
                result.Add(await AddUser(user));
            }

            return result;
        }

        public async Task<User> DeleteUser(Guid id)
        {
            var originUser = await base.Single(x => x.Id == id);

            if (originUser.Jobs.Count > 0)
            {
                throw new Exception("Jobs is not empty.");
            }

            var result = await base.Delete(originUser);
            return result ? originUser : null;
        }

        public async Task<IList<User>> DeleteUsers(IList<Guid> ids)
        {
            var result = new List<User>();

            foreach (var id in ids)
            {
                result.Add(await DeleteUser(id));
            }

            return result;
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await base.Update(user);
            return result ? await base.Single(x => x.Id == user.Id) : null;
        }

        public async Task<IList<User>> UpdateUsers(IList<User> users)
        {
            var result = new List<User>();

            foreach (var user in users)
            {
                result.Add(await UpdateUser(user));
            }

            return result;
        }
    }
}
