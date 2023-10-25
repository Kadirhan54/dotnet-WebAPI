using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Common
{
    public interface IDeletedByEntity
    {
        DateTime? DeletedAt { get; set; }
        string? DeletedByEntity { get; set; }
        bool? IsDeleted { get; set; }
    }
}
