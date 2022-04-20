using CRUD.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Context
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet <Table_Carta> Table_Carta { get; set; }

        public DbSet <View_Carta> View_Carta { get; set; }

        public DbSet <Table_Tipo> Table_Tipo { get; set; }
    }

}
