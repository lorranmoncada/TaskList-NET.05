using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasklist.Core.DataInterface;
using Tasklist.Domain.Enum;
using Tasklist.Domain.Model;

namespace Tasklist.Infraestructure
{
    public class TaskContext : DbContext, IUnitOfWork
    {

        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options) { }

        public DbSet<ToDoTask> ToDoTask { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {// seleciona todas as propriedades do tipo string e seta o tipo de coluna como varchar(100)
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
        }

        private string GetStringConectionConfig()
        {
            string strCon = "Server=(localdb)\\mssqllocaldb;Database=TaskDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            return strCon;
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                    entry.Property("DataEdicao").CurrentValue = null;
                    entry.Property("DataRemocao").CurrentValue = null;
                }
                // Se a entidade foi atualizada não sera atualizado o valor DataCadastro nem  DataRemocao pois somente é para adicionar DataCriacao no momento de cadastro da entidade no banco
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataEdicao").CurrentValue = DateTime.Now;
                    entry.Property("DataCriacao").IsModified = false;
                    
                }
            }
            return await base.SaveChangesAsync() > 0;
        }

    }
}
