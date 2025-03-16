namespace Kazue.Domain.Entities.Service;

public class ServiceEntity
{
    public Guid ID_SERVICE { get; set; }
    public string CD_SERVICE { get; set; } = string.Empty;
    public string DS_SERVICE { get; set; } = string.Empty;
    public decimal VL_PRICE { get; set; }
}
