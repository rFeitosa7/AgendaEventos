using Agendamento_de_Eventos.Models;
using Microsoft.EntityFrameworkCore;

namespace Agendamento_de_Eventos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        { 
        }

        public DbSet<AgendamentoModel> Agendamento {  get; set; }
    }
}
