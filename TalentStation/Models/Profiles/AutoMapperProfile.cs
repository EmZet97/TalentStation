using AutoMapper;
using TalentStation.Models.Common;
using TalentStation.Models.Database.DbModels;

namespace TalentStation.Models.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRequest, UserDbModel>()
                .ForMember(u => u.Id, conf => conf.Ignore())
                .ForMember(u => u.Email, conf => conf.MapFrom(u => u.Email.ToLower()));

            CreateMap<UserDbModel, UserResponse>();
        }
    }
}
