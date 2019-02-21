using System;

namespace BrekkenScan.Domain.Entities
{
    public class Consume
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Barcode { get; set; }
    }
}
