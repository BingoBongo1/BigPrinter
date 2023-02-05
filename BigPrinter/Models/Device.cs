using System;
using System.Collections.Generic;

namespace BigPrinter.Models
{
    public partial class Device
    {
        public Device()
        {
            Claims = new HashSet<Claim>();
        }

        public int Id { get; set; }
        public string NameDevice { get; set; } = null!;
        public string ModelDevice { get; set; } = null!;
        public int IdtypeName { get; set; }

        public virtual Type IdtypeNameNavigation { get; set; } = null!;
        public virtual ICollection<Claim> Claims { get; set; }
    }
}
