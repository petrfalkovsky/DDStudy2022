using AutoMapper;
using Common;

namespace Api
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Models.CreateUserModel, DAL.Entites.User>()
                .ForMember(d=>d.Id, m=>m.MapFrom(s=>Guid.NewGuid()))
                .ForMember(d=>d.PasswordHash, m=>m.MapFrom(s=>HashHelper.GetHash(s.Password)))
                .ForMember(d=>d.BirthDate, m=>m.MapFrom(s=>s.BirthDate.UtcDateTime));
            CreateMap<DAL.Entites.User, Models.UserModel>();

            CreateMap<DAL.Entites.Attach, Models.AttachModel>();

            CreateMap<Models.CreatePostModel, DAL.Entites.Post>()
                .ForMember(d => d.Id, m => m.MapFrom(s => Guid.NewGuid()))
                .ForMember(d => d.Created, m => m.MapFrom(s => DateTime.UtcNow));
        }
    }
}
