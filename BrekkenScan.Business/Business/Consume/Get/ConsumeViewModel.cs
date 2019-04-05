using System.Collections.Generic;

namespace BrekkenScan.Business.Business.Consume.Get
{
    public class ConsumeViewModel
    {
        public int Total { get; set; }
        public IEnumerable<string> Tonight { get; set; }
    }
}