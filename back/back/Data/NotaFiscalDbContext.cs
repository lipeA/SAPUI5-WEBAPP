using Microsoft.EntityFrameworkCore;
using back.Models;



namespace back.Data

{
    public class NotaFiscalDbContext : DbContext
    {

        public NotaFiscalDbContext(DbContextOptions<NotaFiscalDbContext> options): base(options) 
        { 





        }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Fornecedor> Fornecedor { get; set; }

        public DbSet<NotaFiscal> NotaFiscal { get; set; }


    }
}
