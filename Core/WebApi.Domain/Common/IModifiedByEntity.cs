using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Common
{
    public interface IModifiedByEntity
    {
        DateTime? ModifiedAt { get; set; }
        string? ModifiedByUserId { get; set; }
    }
}
