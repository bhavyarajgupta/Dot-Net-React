using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class BasketItemDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public long ProductPrice { get; set; }

        public int Quantity { get; set; }

        public List<string> PictureUrl { get; set; }

        public string Brand { get; set; }

        public string Type { get; set; }

    }
}