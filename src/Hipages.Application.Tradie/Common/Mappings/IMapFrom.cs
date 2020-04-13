using AutoMapper;

namespace Hipages.Application.Tradie.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}