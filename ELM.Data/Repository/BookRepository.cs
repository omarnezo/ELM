using Dapper;
using ELM.Common.Dto;
using ELM.Core.Entities;
using ELM.Data.Context;
using ELM.Data.IRepository;

namespace ELM.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ELMContext _context;
        public BookRepository(ELMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooks(BookFilterDto bookFilterDto)
        {
            var pageNumber = (bookFilterDto.PageNumber - 1) * bookFilterDto.PageSize;
            // string query = String.Format("SELECT * FROM BOOK WHERE JSON_VALUE(BookInfo, '$.BookTitle') LIKE '%{0}%' OR JSON_VALUE(BookInfo, '$.BookDescription') LIKE '%{0}%'  ORDER BY BookId OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY", bookFilterDto.SearchText, pageNumber, bookFilterDto.PageSize);
            string query = String.Format("SELECT BookId ,BookInfo FROM book" +
                " WHERE JSON_VALUE(BookInfo, '$.Author') LIKE '%{0}%' OR" +
                " JSON_VALUE(BookInfo, '$.BookDescription') LIKE '%{0}%' OR" +
                " JSON_VALUE(BookInfo, '$.BookTitle') LIKE '%{0}%' OR" +
                "  JSON_VALUE(BookInfo, '$.PublishDate') LIKE '%{0}%'" +
                " AND ISJSON(BookInfo) > 0" +
                " ORDER BY BookId OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY", bookFilterDto.SearchText, pageNumber, bookFilterDto.PageSize);
            using (var connection = _context.CreateConnection())
            {
                var books = await connection.QueryAsync<Book>(query);
                return books.ToList();
            }
        }
    }
}
