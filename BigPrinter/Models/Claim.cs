using System;
using System.Collections.Generic;

namespace BigPrinter.Models
{
    public partial class Claim
    {
        public int Id { get; set; }
        public int Idcabinet { get; set; }
        public int IdclaimType { get; set; }
        public int IdclaimDevices { get; set; }
        public string NameOfMatherial { get; set; } = null!;
        public int AmountOfMatherial { get; set; }
        public int Cost { get; set; }

        public virtual Cabinet IdcabinetNavigation { get; set; } = null!;
        public virtual Device IdclaimDevicesNavigation { get; set; } = null!;
        public virtual ClaimType IdclaimTypeNavigation { get; set; } = null!;
    }
}
