using DotNetWebApiCRUD.Models;
using Microsoft.EntityFrameworkCore;


namespace DotNetWebApiCRUD.Data
{
    public class DataBase : DbContext
    {
        public DataBase(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Users> User { get; set; }
    }
}
