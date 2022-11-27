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
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            /// <summary> Chave primaria </summary>
            builder.HasKey(x => x.Id);
            /// <summary> Propriedade Name tem o tamanho máximo de 100 caracteres e é obrigatoria </summary>
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            /// <summary> Propriedade Description tem o tamanho máximo de 200 e é obrigatoria </summary>
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            /// <summary> Propriedade Price tem o tamanho máximo de 10 e  tem duas casas de precisão </summary>
            builder.Property(x => x.Price).HasPrecision(10, 2);
            /// <summary> Relacionamento um para muitos (Uma categoria para muitos produtos) </summary>
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}
