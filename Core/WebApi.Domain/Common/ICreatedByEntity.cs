using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Common
{
    public interface ICreatedByEntity
    {
        DateTime CreatedAt { get; set; }
        string CreatedByUserId { get; set; }
    }
}
