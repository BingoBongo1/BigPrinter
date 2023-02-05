using System.Collections.Generic;

namespace BigPrinter.Models
{
    public partial class Cabinet
    {
        public Cabinet()
        {
            Claims = new HashSet<Claim>();
        }

        public int Id { get; set; }
        public string Cabinet1 { get; set; } = null!;

        public virtual ICollection<Claim> Claims { get; set; }
    }
}
