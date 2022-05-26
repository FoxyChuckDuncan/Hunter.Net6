using AutoMapper;
using Hunter.API.Data;
using Hunter.API.DTOs;

namespace Hunter.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Company, GetCompanyDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company, UpdateCompanyDto>().ReverseMap();

            CreateMap<Project, GetProjectDto>().ReverseMap();
        }
    }
}
