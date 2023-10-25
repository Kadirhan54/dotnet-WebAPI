using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Common
{
    public class EntityBase<TKey> : ICreatedByEntity, IModifiedByEntity , IDeletedByEntity
    {
        public TKey Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedByUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedByUserId { get; set; }

        public DateTime? DeletedAt { get; set; }
        public string? DeletedByEntity { get; set; }
        public bool? IsDeleted { get ; set ; }
    }
}
