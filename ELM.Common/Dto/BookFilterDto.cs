namespace ELM.Common.Dto
{
    public class BookFilterDto
    {
        public string? SearchText { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
