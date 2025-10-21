using System;
using AutoMapper;
using LojaApi.Entities;
using LojaApi.Infra.DTOs;

namespace LojaApi.Mapping;

public class MappingProfile : Profile
{

    public MappingProfile()
    {
        CreateMap<PedidoProduto, ProdutoPedidoDto>(0)
            .ForMember(dest => dest.ProdutoId, opt => opt.MapFrom(src => src.ProdutoId))
            .ForMember(dest => dest.NomeProduto, opt => opt.MapFrom(src => src.Produto != null ? src.Produto.Descricao : string.Empty))
            .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.Produto != null ? src.Produto.Valor : 0m))
            .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src));

        CreateMap<Pedido, PedidoDetalhadoDto>()
            .ForMember(dest => dest.NomeCliente, opt => opt.MapFrom(src => src.Cliente != null ? src.Cliente.Nome : string.Empty))
            .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.PedidoProdutos));

        CreateMap<Cliente, ClienteDetalhadoDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo))
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco != null ? src.Endereco : null));

        CreateMap<Endereco, EnderecoDto>();

        CreateMap<Produto, ProdutoResumoDto>();
    }

}
