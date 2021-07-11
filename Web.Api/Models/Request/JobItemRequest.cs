

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using Web.Api.Core.Domain.Enums;

namespace Web.Api.Models.Request
{
  public class JobItemRequest
  {

    [Required]
    public string DataSourceUrl { get; set; }
    }
}
