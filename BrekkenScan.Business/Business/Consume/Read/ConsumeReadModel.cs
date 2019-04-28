using System.Collections.Generic;

namespace BrekkenScan.Business.Business.Consume.Get
{
    public class ConsumeReadModel
    {
        public int Total { get; set; }
        public IEnumerable<string> Tonight { get; set; }
    }
}