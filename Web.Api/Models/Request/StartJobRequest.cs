

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web.Api.Core.Domain.Enums;

namespace Web.Api.Models.Request
{
  public class StartJobRequest
  {
    [JsonConverter(typeof(StringEnumConverter))]
    [Required]
    public JobType Type { get; set; }

    [Required]
    public List<JobItemRequest> Items { get; set; }
  }
}
