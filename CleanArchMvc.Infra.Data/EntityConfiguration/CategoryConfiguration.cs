using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.EntityConfiguration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            /// <summary> Chave primaria </summary>
            builder.HasKey(x => x.Id);
            /// <summary> Propriedade Name tem o tamanho máximo de 100 caracteres e é obrigatoria </summary>
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }
}
