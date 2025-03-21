namespace Kazue.Domain.Entities.Queue;

public class QueueEntity
{
    public long ID_QUEUE { get; set; }
    public DateTime DT_CHECKIN_AT { get; set; }
    public DateTime? DT_CHECKOUT_AT { get; set; }
    public decimal VL_AMOUNT { get; set; }

    public Guid ID_CUSTOMER { get; set; }
    public string DS_CUSTOMER_FULLNAME { get; set; } = string.Empty;
    public string? DS_CUSTOMER_NICKNAME { get; set; } = string.Empty;
    public bool CK_CUSTOMER_NICKNAME_PREFERENCE { get; set; } 

    public Guid ID_BARBER { get; set; }
    public string DS_BARBER_FULLNAME { get; set; } = string.Empty;
    public string? DS_BARBER_NICKNAME { get; set; } = string.Empty;
    public bool CK_BARBER_NICKNAME_PREFERENCE { get; set; }

    public long ID_STATUS { get; set; }
    public string CD_STATUS { get; set; } = string.Empty;
    public string DS_STATUS { get; set; } = string.Empty;
    public string IDS_SERVICES { get; set; } = string.Empty;

    public int QT_RECORDS { get; set; }
    public int QT_ROWS { get; set; }
}
