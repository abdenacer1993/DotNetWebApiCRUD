using DotNetWebApiCRUD.Data;
using DotNetWebApiCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebApiCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly DataBase dbContext;

        public UsersController(DataBase dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await dbContext.User.ToListAsync());
             
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await dbContext.User.FindAsync(id);

            if (user == null)
            {
                NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUsersRequest addUsersRequest)
        {
            var user = new Users()
            {
                Id = Guid.NewGuid(),
                FullName = addUsersRequest.FullName,
                Email = addUsersRequest.Email,
                Password = addUsersRequest.Password,
                PhoneNumber = addUsersRequest.PhoneNumber
            };
            await dbContext.User.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return Ok(user);


        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UpdateUsersRequest updateUsersRequest) 
        {
           var user =await dbContext.User.FindAsync(id);
            if (user != null) 
            {
                user.FullName = updateUsersRequest.FullName;
                user.Email = updateUsersRequest.Email;
                user.Password = updateUsersRequest.Password;
                user.PhoneNumber = updateUsersRequest.PhoneNumber;

                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await dbContext.User.FindAsync(id);

            if (user != null)
            {
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }

    }

}
