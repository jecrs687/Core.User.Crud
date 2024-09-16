using System.ComponentModel.DataAnnotations;

namespace Core.User.Crud.Application.User.QueryParams;

public class GetUsersQueryParam
{
    [Required]
    [Range(0, int.MaxValue)]
    public int page { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int pageSize { get; set; }
}