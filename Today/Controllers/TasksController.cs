using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Today.Models;

namespace Today.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TodayDbcontext dbbcontext;

        public TasksController(TodayDbcontext dbbcontext)
        {
            this.dbbcontext = dbbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await dbbcontext.TaskDetailss.ToListAsync());
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetbyId(string id)
        {
            var person = await dbbcontext.TaskDetailss.FirstOrDefaultAsync(x => x.Equals(id));
            return Ok(person);
        }
        [HttpPost]
        public async Task<IActionResult> register(TaskDetails task)
        {
            var per = new TaskDetails()
            {
                TaskId = task.TaskId,
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
            };
            await dbbcontext.TaskDetailss.AddAsync(per);
            await dbbcontext.SaveChangesAsync();
            return Ok(per);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> update(int id, UpdateTask updatetask)
        {
            var userr = await dbbcontext.TaskDetailss.FindAsync(id);
            if (userr != null)
            {
                userr.TaskId = updatetask.TaskId;
                userr.TaskName = updatetask.TaskName;
                userr.TaskDescription = updatetask.TaskDescription;

                await dbbcontext.SaveChangesAsync();

                return Ok(userr);


            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var userr = await dbbcontext.TaskDetailss.FindAsync(id);

            if (userr != null)
            {
                dbbcontext.Remove(userr);
                await dbbcontext.SaveChangesAsync();
                return Ok($"User {id} deleted");
            }
            return NotFound();
        }

    }
}
