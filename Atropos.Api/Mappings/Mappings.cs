using Atropos.Api.Dtos;
using Atropos.Data.Models;
using AutoMapper;

namespace Atropos.Api.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
