using Kazue.Domain.Helper;

namespace Kazue.Domain.Entities.Person;

public abstract class PersonEntity
{
    public string DS_NAME { get; set; } = string.Empty;
    public string DS_SURNAME { get; set; } = string.Empty;
    public string? DS_NICKNAME { get; set; } = string.Empty;
    public string? DS_EMAIL { get; set; } = string.Empty;
    public string? DS_PHONE { get; set; } = string.Empty;
    public char TP_STATUS { get; set; }
    public DateTime DT_BIRTH { get; set; }
    public DateTime DT_REGISTRY { get; set; }
}
