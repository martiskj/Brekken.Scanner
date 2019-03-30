using System.Collections.Generic;

namespace BrekkenScan.Web.Models.Consume
{
    public class ConsumeViewModel
    {
        public int Total { get; set; }

        public IEnumerable<string> Tonight { get; set; }

        public decimal PPHPT { get; set; }
    }
}