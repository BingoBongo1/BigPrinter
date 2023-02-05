using System;
using System.Collections.Generic;

namespace BigPrinter.Models
{
    public partial class ClaimType
    {
        public ClaimType()
        {
            Claims = new HashSet<Claim>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<Claim> Claims { get; set; }
    }
}
