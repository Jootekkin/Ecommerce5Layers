namespace Ecommerce.Core.Pagination
{
    public class PaginationResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < TotalPages;
        public IReadOnlyList<T> Data { get; set; } = new List<T>();

        public PaginationResponse() { }

        public PaginationResponse(IReadOnlyList<T> data, int totalRecords, int pageNumber, int pageSize)
        {
            Data = data;
            TotalRecords = totalRecords;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
        }
    }
}
