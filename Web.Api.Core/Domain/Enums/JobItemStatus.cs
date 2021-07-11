using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.Core.Domain.Enums
{
    public enum JobItemStatus : int
    {
        CREATED = 1,
        PROCESSING = 2,
        PROCESSED = 3,
        FAILED = 4
    }
}
