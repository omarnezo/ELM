

using AutoMapper;
using ELM.Common.Dto;
using ELM.Core.Entities;
using Newtonsoft.Json;

namespace ELM.Infraa.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(s => s.BookInfo, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<BookInfoDto>(src.BookInfo)));
            CreateMap<BookDto, Book>();
        }
    }
}
