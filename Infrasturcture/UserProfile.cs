using AutoMapper;
using MSBProCrudApp.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRequest, User>()
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));

        CreateMap<TodoRequest, Todos>()
            .ForMember(dest => dest.UId, opt => opt.MapFrom(src => src.UId))
            .ForMember(dest => dest.UId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details))
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

    }
}
