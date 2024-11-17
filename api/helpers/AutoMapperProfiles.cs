namespace FBB.api.helpers;

public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
           // CreateMap<FBB.data.models.Image, ImageDto>().ReverseMap();
           CreateMap<AppUser, UserDto>();
           CreateMap<UserForRegisterDto, AppUser>();
           CreateMap<UserForUpdateDto, AppUser>()
           .ForMember(dest => dest.Id, opt => opt.Ignore());
          
           CreateMap<string, DateOnly>().ConvertUsing(s => DateOnly.Parse(s));
        }


    }
