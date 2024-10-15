using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class MatchLogImportFiles
    {
        public int ImportID { get; set; }
        public byte[] Bytes { get; set; }

        public virtual MatchLogImports Import { get; set; }
    }
}
