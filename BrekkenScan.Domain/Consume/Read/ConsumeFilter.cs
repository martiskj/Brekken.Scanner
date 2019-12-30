using System;

namespace BrekkenScan.Domain
{
    public class ConsumeFilter
    {
        public DateTime? From { get; set; }

        public DateTime To { get; set; } = DateTime.Now;
    }
}