namespace Kazue.Domain.Entities.Queue;

public class QueueEntity
{
    public Guid ID_QUEUE { get; set; }
    public DateTime DT_CHECKIN_AT { get; set; }
    public DateTime? DT_CHECKOUT_AT { get; set; }
    public decimal VL_AMOUNT { get; set; }

    public Guid ID_CUSTOMER { get; set; }
    public string DS_CUSTOMER_NAME { get; set; } = string.Empty;
    public string DS_CUSTOMER_SURNAME { get; set; } = string.Empty;
    public string? DS_CUSTOMER_NICKNAME { get; set; } = string.Empty;

    public Guid ID_BARBER { get; set; }
    public string DS_BARBER_NAME { get; set; } = string.Empty;
    public string DS_BARBER_SURNAME { get; set; } = string.Empty;
    public string? DS_BARBER_NICKNAME { get; set; } = string.Empty;

    public Guid ID_STATUS { get; set; }
    public string CD_STATUS { get; set; } = string.Empty;
    public string DS_STATUS { get; set; } = string.Empty;

    public string IDS_SERVICES { get; set; } = string.Empty;
}
