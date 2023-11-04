using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Today.Models;

namespace Today.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TodayDbcontext dbcontext;

        public UserController(TodayDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await dbcontext.Userdetailss.ToListAsync());
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult>GetbyId(string id)
        {
            var person= await dbcontext.Userdetailss.FirstOrDefaultAsync(x=>x.Equals(id));
            return Ok(person);
        }
        [HttpPost]
        public async Task<IActionResult>register(UserDetails user)
        {
            var per = new UserDetails()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone
            };
            await dbcontext.Userdetailss.AddAsync(per);
            await dbcontext.SaveChangesAsync();
            return Ok(per);
            
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult>update(int id, Updateuser updateuser)
        {
            var userr = await dbcontext.Userdetailss.FindAsync(id);
            if(userr!=null)
            {
                userr.Name = updateuser.UserName;
                userr.Email=updateuser.Email;
                userr.Password = updateuser.Password;
                userr.Phone = updateuser.Phone;

                await dbcontext.SaveChangesAsync();

                return Ok(userr);


            }
            return NotFound();
           
            

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userr = await dbcontext.Userdetailss.FindAsync(id);
                                        
            if (userr!= null)
            {
                dbcontext.Remove(userr);
                await dbcontext.SaveChangesAsync();
                return Ok($"User {id} deleted");
            }
            return NotFound();
        }
        [HttpGet]
        [Route("{email},{pswd}")]
        public async Task<IActionResult>log(string email,string pswd)
        {
            var usid = await dbcontext.Userdetailss.Where(x => x.Email == email).ToListAsync();
            var ps= await dbcontext.Userdetailss.Where(x => x.Password == pswd).ToListAsync();
            if(usid.Count()!=0&&ps.Count()!=0)
            {
                return Ok("hello user");
            }
            return NotFound();

        }






    }
}
