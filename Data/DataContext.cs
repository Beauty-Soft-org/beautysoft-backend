using Beautysoft.Models;
using BeautySoftAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautySoftAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RegisterViewModel> Registros { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<MensagemTemporariaModel> MensagensTemporarias { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}
