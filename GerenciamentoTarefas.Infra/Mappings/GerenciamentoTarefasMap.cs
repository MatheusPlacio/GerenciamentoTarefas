using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoTarefas.Infra.Mappings;

public class GerenciamentoTarefasMap : IEntityTypeConfiguration<Domain.Entities.GerenciamentoTarefa>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.GerenciamentoTarefa> builder)
    {
        builder.ToTable("GerenciamentoTarefas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Titulo)
            .HasColumnName("Titulo")
            .HasColumnType("VARCHAR(200)")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao")
            .HasColumnType("VARCHAR(1000)")
            .IsRequired(false);

        builder.Property(x => x.DataCriacao)
            .HasColumnName("DataCriacao")
            .HasColumnType("DATETIME2")
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.Concluida)
            .HasColumnName("Concluida")
            .HasColumnType("BIT")
            .IsRequired()
            .HasDefaultValue(false);
    }
}
