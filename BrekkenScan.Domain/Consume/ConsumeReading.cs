using System;

namespace BrekkenScan.Domain.Models
{
    public class ConsumeReading
    {
        public int Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Product { get; set; }

        public string Barcode { get; set; }
    }
}