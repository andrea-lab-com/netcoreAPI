

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Web.Api.Models.Request
{
    public class JobItemRequest
    {

        [Required]
        public string DataSourceUrl { get; set; }
    }
}
