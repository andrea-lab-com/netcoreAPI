using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Core.Domain.Enums;

namespace Web.Api.Models.Response
{
    public class JobLogResponse
    {
        public int JobLogId { get; set; }
        public int JobId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public JobType JobType { get; set; }
        public int JobItemId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public JobItemStatus JobItemStatus { get; set; }

        public DateTime Date { get; set; }
        public string DataSourceUrl { get; set; }
        public string Error { get; set; }
    }
}
