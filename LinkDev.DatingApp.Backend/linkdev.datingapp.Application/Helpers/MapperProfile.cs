using System.Linq;
using AutoMapper;
using LinkDev.DatingApp.Application.BE.DTOs;
using LinkDev.DatingApp.Core;

namespace LinkDev.DatingApp.Application.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser,MemberDto>().ForMember(dest=>dest.PhotoUrl,
                    opt=>opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<Photo,PhotoDTO>();
            CreateMap<MemberDto,AppUser>();
            CreateMap<UpdateMemberDto,AppUser>();

            
        }
    }
}