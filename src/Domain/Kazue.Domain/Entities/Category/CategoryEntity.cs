namespace Kazue.Domain.Entities.Category;

public class CategoryEntity
{
    public long ID_CATEGORY { get; set; }
    public string CD_CATEGORY { get; set; } = string.Empty;
    public string DS_CATEGORY { get; set; } = string.Empty;
    public int QT_RECORDS { get; set; }
    public int QT_ROWS { get; set; }
}
