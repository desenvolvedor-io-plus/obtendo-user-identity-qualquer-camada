using AutoMapper;
using DevIO.App.ViewModels;
using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Produtos;

namespace DevIO.App.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}