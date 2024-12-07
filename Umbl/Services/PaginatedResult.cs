namespace Umbl.Services
{
    public class PaginatedResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalItems { get; set; } 
        public int PageNumber { get; set; } 
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }


}
