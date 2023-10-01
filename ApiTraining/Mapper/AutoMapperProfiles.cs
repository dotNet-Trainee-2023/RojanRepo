using ApiTraining.Models;
using ApiTraining.Models.Dto;
using AutoMapper;
namespace ApiTraining.Mapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PlaceDto, Place>().ReverseMap();
            CreateMap<PlaceCreateDto, Place>().ReverseMap();
            //CreateMap<UserDTO, UserDomainModel>().ForMember(x => x.FullName, option => option.MapFrom(x=> x.DisplayName))
            //    .ReverseMap();
        }
    }
}
