using ELM.Common.Dto;
using ELM.Core.Entities;

namespace ELM.Data.IRepository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks(BookFilterDto bookFilterDto);
    }
}
