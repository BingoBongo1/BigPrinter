using System;
using System.Collections.Generic;

namespace BigPrinter.Models
{
    public partial class Type
    {
        public Type()
        {
            Devices = new HashSet<Device>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<Device> Devices { get; set; }
    }
}
