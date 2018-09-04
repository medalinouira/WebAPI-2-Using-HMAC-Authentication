using System.Linq;
using SampleWebAPI.Domain.Entities;
using SampleWebAPI.Domain.IServices;
using SampleWebAPI.Domain.IRepositories;

namespace SampleWebAPI.Data.Services
{
    public class UserServices : IUserServices
    {
        private IGenericRepository<User> _iUserRepository;

        public UserServices(IGenericRepository<User> _iUserRepository)
        {
            this._iUserRepository = _iUserRepository;
        }

        public bool IsUserExist(string email, string password)
        {
            var users = _iUserRepository.GetAll();
            if (users == null)
                return false;
            var user = users.Where(u => u.email.ToUpper().Equals(email.ToUpper()) && u.password.ToUpper().Equals(password.ToUpper()));
            return user != null && user.Any() ? true : false;
        }

        public bool IsConfidentials(string email)
        {
            var users = _iUserRepository.GetAll();
            if (users == null)
                return false;
            var user = users.Where(u => u.email.ToUpper().Equals(email.ToUpper()));
            return user != null && user.Any() ? (user.FirstOrDefault()).IsConfidentials : false;
        }
    }
}
