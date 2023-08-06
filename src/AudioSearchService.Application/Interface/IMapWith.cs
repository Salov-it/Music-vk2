using AutoMapper;

namespace AudioSearchService.Application.Interface
{
    internal interface IMapWith<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
