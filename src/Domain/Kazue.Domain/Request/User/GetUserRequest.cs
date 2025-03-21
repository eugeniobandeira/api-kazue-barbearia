using System.ComponentModel.DataAnnotations;

namespace Kazue.Domain.Request.User;

public class GetUserRequest
{
    public string Fullname { get; set; } = string.Empty;
    public string Nickname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    [Required] 
    public int Page { get; set; }

    [Required]
    public int PageSize { get; set; }
}
