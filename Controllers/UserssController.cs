using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketCinemaAPIService.Dao;
using PocketCinemaAPIService.Models;

namespace PocketCinemaAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserssController : ControllerBase
    {
        private UserDao usersDao;
        public UserssController(UserDao usersDao)
        {
            this.usersDao = usersDao;
        }

        [HttpGet(Name = "getUsers")]
        public List<User>? GetUsers()
        {
            try
            {
                var res = usersDao.GetAllUsers();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database connection failed!");
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
