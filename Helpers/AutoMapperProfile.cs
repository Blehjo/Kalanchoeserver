using AutoMapper;
using KalanchoeAI_Backend.Entities;
using KalanchoeAI_Backend.Models.Users;

namespace KalanchoeAI_Backend.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            CreateMap<UserInfo, AuthenticateResponse>();

            // RegisterRequest -> User
            CreateMap<RegisterRequest, UserInfo>();

            // UpdateRequest -> User
            CreateMap<UpdateRequest, UserInfo>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));
        }
    }
}