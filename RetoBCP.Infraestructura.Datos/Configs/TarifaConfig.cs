using System;
using System.Collections.Generic;
using System.Text;
using RetoBCP.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RetoBCP.Infraestructura.Datos.Configs
{
    class TarifaConfig : IEntityTypeConfiguration<Tarifa>
    {
        public void Configure(EntityTypeBuilder<Tarifa> builder)
        {
            builder.ToTable("tblTarifa");
            builder.HasKey(c => c.Id);
        }
    }
}
