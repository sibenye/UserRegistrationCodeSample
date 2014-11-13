using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using UserRegistrationSample.Models;
using UserRegistrationSample.Repositories;

namespace UserRegistrationSample.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly UserRepository _userRepository;
        public AccountController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _userRepository.RegisterUser(model);
            }
            catch (SqlException e)
            {
                return InternalServerError();
            }           

            return Ok();
        }

        //TODO: implement logout
        // POST api/Account/Logout
        //[Route("Logout")]
        //public IHttpActionResult Logout()
        //{

        //}

        //TODO: implement login
        // POST api/Account/Login
        //[Route("Login")]
        //public IHttpActionResult Login()
        //{

        //}
    }
}
