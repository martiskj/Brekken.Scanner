using System.Collections.Generic;

namespace BrekkenScan.Domain.Models
{
    public class ConsumeReadModel
    {
        public int Total { get; set; }
        public IEnumerable<string> Tonight { get; set; }
    }
}