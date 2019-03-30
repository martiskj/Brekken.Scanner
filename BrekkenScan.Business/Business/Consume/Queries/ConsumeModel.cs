using System.Collections.Generic;

namespace BrekkenScan.Business.Business.Consume.Queries
{
    public class ConsumeModel
    {
        public int Total { get; set; }
        public IEnumerable<string> Tonight { get; set; }
    }
}