using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasklist.Domain.Model;

namespace Tasklist.Infraestructure.Mappings
{
    public class ToDoTaskMapping : IEntityTypeConfiguration<ToDoTask>
    {
        public void Configure(EntityTypeBuilder<ToDoTask> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Titulo)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.ToTable("ToDoTask");
        }
    }
}
