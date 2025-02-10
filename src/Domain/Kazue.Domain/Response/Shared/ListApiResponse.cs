namespace Kazue.Domain.Response.Shared;

public class ListApiResponse<TEntity> where TEntity : class
{
    public List<TEntity> Response { get; set; } = [];
    public int ResultCount { get; set; }
    public int RowsCount { get; set; }
}
