using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RetoBCP.Dominio;
using RetoBCP.Infraestructura.Datos.Configs;

namespace RetoBCP.Infraestructura.Datos.Contextos
{
    public class TarifaContexto : DbContext
    {
        string SERVER = Environment.GetEnvironmentVariable("SERVER");
        string PORT = Environment.GetEnvironmentVariable("PORT");
        string DATABASE = Environment.GetEnvironmentVariable("DATABASE");
        string USERNAME = Environment.GetEnvironmentVariable("USERNAME");
        string PASSWORD = Environment.GetEnvironmentVariable("PASSWORD");
        string INTEGRATED_SECURITY = Environment.GetEnvironmentVariable("INTEGRATED_SECURITY");
        string TRUST_SERVER_CERTIFICATE = Environment.GetEnvironmentVariable("TRUST_SERVER_CERTIFICATE");

        public TarifaContexto()
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<BcpTipoCambio> BcpTipoCambios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("Server=tcp:serverretobcp.database.windows.net,1433;Initial Catalog=app-tipocambio;Persist Security Info=False;User ID=adminretobcp;Password=@dminretoBCP;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //options.UseSqlServer($"Server={SERVER},{PORT};Initial Catalog={DATABASE};Persist Security Info=False;User ID={USERNAME};Password={PASSWORD};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TarifaConfig());
            builder.ApplyConfiguration(new BcpTipoCambioConfig());
            
        }
    }
}
