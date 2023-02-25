using Microsoft.EntityFrameworkCore;

namespace New_Curd_Operation.Model.Data_Model
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
               : base(options)

        { }
        public DbSet<User> Userr { get; set; }
    }
}


