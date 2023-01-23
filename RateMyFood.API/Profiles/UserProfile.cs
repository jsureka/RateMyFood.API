using AutoMapper;

namespace RateMyFood.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, Models.UserDto>();
        }
    }
}
