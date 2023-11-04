using Microsoft.EntityFrameworkCore;

namespace Today.Models
{
    public class TodayDbcontext:DbContext
    {
        public TodayDbcontext(DbContextOptions contextOptions):base(contextOptions) { }

        public virtual DbSet<UserDetails> Userdetailss {  get; set; }
        public virtual DbSet<TaskDetails> TaskDetailss { get; set; }
      
    }
}
