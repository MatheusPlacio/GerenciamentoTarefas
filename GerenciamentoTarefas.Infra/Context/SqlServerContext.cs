using GerenciamentoTarefas.Domain.Entities;
using GerenciamentoTarefas.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTarefas.Infra.Context;

public class SqlServerContext : DbContext
{
    public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
    { }

    public DbSet<Domain.Entities.GerenciamentoTarefa> GerenciamentoTarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new GerenciamentoTarefasMap());
    }
}
