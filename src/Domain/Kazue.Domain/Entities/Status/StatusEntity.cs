namespace Kazue.Domain.Entities.Status;

public class StatusEntity
{
    public long ID_STATUS { get; set; }
    public string CD_STATUS { get; set; } = string.Empty;
    public string DS_STATUS { get; set; } = string.Empty;

    public long ID_CATEGORY { get; set; }
    public string CD_CATEGORY { get; set; } = string.Empty;
    public string DS_CATEGORY { get; set; } = string.Empty;

    public int QT_RECORDS { get; set; }
    public int QT_ROWS { get; set; }
}
