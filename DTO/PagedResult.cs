namespace Jobs.DTO
{
    
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int TotalCount { get; set; }    // total items before pagination
        public int PageNumber { get; set; }    // current page number
        public int PageSize { get; set; }      // size per page
    }

    
}
