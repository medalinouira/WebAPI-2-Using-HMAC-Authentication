using System.Web.Http;
using System.Web.Routing;
using SampleWebAPI.API.Filters;
using SampleWebAPI.Domain.IServices;

namespace SampleWebAPI.API.Controllers
{
    public class UserController : ApiController
    {
        private IUserServices _iUserServices;

        public UserController(IUserServices _iUserServices)
        {
            this._iUserServices = _iUserServices;
        }

        [Route("api/authenticate/{email}/{password}")]
        [HttpGet]
        public bool Authenticate(string email, string password)
        {
            return _iUserServices.IsUserExist(email, password);
        }

        [HMACAuthentication]
        [HttpGet]
        [Route("api/confidentials/{email}")]
        public bool Confidentials(string email)
        {
            return _iUserServices.IsConfidentials(email);
        }
    }
}