//important
using apiprueba.Models;
using Microsoft.EntityFrameworkCore;

namespace apiprueba.Data
{
    //creating the connection wth the DB
    //for all we need this clase, CREATE, UPDATE...
    public class ApiContext : DbContext
    {
        //save information
        public DbSet<Notas> Notas { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

    
    }

}