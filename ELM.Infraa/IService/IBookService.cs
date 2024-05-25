using ELM.Common.Dto;

namespace ELM.Infraa.IService
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooks(BookFilterDto bookFilterDto);
    }
}
