using AutoMapper;
using ELM.Common.Dto;
using ELM.Data.IRepository;
using ELM.Infraa.IService;

namespace ELM.Infraa.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookDto>> GetBooks(BookFilterDto bookFilterDto)
        {
            var result = await _bookRepository.GetBooks(bookFilterDto);
            var res = _mapper.Map<IEnumerable<BookDto>>(result);
            return res;
        }
    }
}
