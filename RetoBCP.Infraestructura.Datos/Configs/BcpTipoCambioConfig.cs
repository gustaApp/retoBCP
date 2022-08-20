using System;
using System.Collections.Generic;
using System.Text;
using RetoBCP.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RetoBCP.Infraestructura.Datos.Configs
{
    class BcpTipoCambioConfig : IEntityTypeConfiguration<BcpTipoCambio>
    {
        public void Configure(EntityTypeBuilder<BcpTipoCambio> builder)
        {
            builder.ToTable("tblBcpTipoCambio");
            builder.HasKey(c => c.Id);
        }
    }
}
