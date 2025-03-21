namespace Kazue.Domain.Entities.User;

public class UserEntity
{
    public Guid ID_USER { get; set; }
    public string DS_FULLNAME { get; set; } = string.Empty;
    public string? DS_NICKNAME { get; set; } = string.Empty;
    public bool CK_NICKNAME_PREFERENCE { get; set; }
    public string DS_EMAIL { get; set; } = string.Empty;
    public string DS_PASSWORD { get; set; } = string.Empty;
    public string DS_PHONE { get; set; } = string.Empty;
    public string DS_ROLE { get; set; } = string.Empty;
    public long ID_STATUS { get; set; }
    public string DS_STATUS { get; set; } = string.Empty;
    public string CD_STATUS { get; set; } = string.Empty;
    public DateTime DT_BIRTH { get; set; }
    public DateTime DT_REGISTRY { get; set; }
    public int QT_RECORDS { get; set; }
    public int QT_ROWS { get; set; }
}
