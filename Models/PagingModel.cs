namespace ProductTask.Models;

public class PagingModel
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    public PagingModel()
    {
        PageNumber = 1;
        PageSize = 10;
        TotalPages = 0;
        TotalItems = 0;
    }
}

public class PaginatedResponse<T>
{
    public List<T> Items { get; set; }
    public PagingModel Paging { get; set; }
}