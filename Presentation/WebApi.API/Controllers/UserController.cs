using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.API.Models;
using WebApi.Domain.Entites;
using WebApi.Persistence.Contexts;

namespace WebApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly WebApiDbContext _context;

        //public UsersController(WebApiDbContext context)
        //{
        //    _context = context;
        //}

        public UsersController()
        {
            _context = new();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _context.Users.ToList();
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("[action]")]
        public IActionResult CreateUser([FromBody] CreateUserRequest createUserRequest)
        {

            try
            {
                User user = new()
                {
                    FirstName = createUserRequest.FirstName,
                    LastName = createUserRequest.LastName,
                    CreatedAt = DateTime.UtcNow,
                    Email = createUserRequest.Email,
                    CreatedByUserId = createUserRequest.CreatedByUserId,
                    PhoneNumber = createUserRequest.PhoneNumber,
                };

                _context.Users.Add(user);

                _context.SaveChanges();

                return Ok();

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPost("[action]")]
        public IActionResult ModifyUser([FromBody] ModifyUserRequest modifyUserRequest)
        {

            try
            {
                var user = _context.Users.FirstOrDefault(x => x.CreatedByUserId == modifyUserRequest.Email);

                if(user == null)
                    return BadRequest();

                user.FirstName = modifyUserRequest.FirstName;
                user.LastName = modifyUserRequest.LastName;
                user.Email = modifyUserRequest.Email;
                user.PhoneNumber = modifyUserRequest.PhoneNumber;
                user.ModifiedAt = DateTime.UtcNow;
                user.ModifiedByUserId = "self";

                _context.SaveChanges();

                return Ok();

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPost("[action]")]
        public IActionResult DeleteUser([FromBody] DeleteUserRequest deleteUserRequest)
        {

            try
            {
                var user = _context.Users.FirstOrDefault(x => x.CreatedByUserId == deleteUserRequest.Email);

                if (user == null)
                    return BadRequest();

                user.DeletedAt = DateTime.UtcNow;
                user.DeletedByEntity = "self";
                user.IsDeleted = true;

                // TODO : When user removed, the fields are removed too as expected. So just modify the entity as removed.
                //_context.Remove(user);

                _context.SaveChanges();

                return Ok();

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
