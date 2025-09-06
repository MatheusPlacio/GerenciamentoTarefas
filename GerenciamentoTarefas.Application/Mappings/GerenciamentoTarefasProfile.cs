using AutoMapper;
using GerenciamentoTarefas.Application.DTOs;
using GerenciamentoTarefas.Domain.Entities;

namespace GerenciamentoTarefas.Application.Mappings;

public class GerenciamentoTarefasProfile : Profile
{
    public GerenciamentoTarefasProfile()
    {
        CreateMap<GerenciamentoTarefa, GerenciamentoTarefasDto>();
        
        CreateMap<CreateGerenciamentoTarefasDto, GerenciamentoTarefa>()
            .ConstructUsing(src => new GerenciamentoTarefa(src.Titulo, src.Descricao));
        
        CreateMap<UpdateGerenciamentoTarefasDto, GerenciamentoTarefa>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.DataCriacao, opt => opt.Ignore());
    }
}
