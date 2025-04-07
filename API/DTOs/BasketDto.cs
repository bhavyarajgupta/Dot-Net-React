using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// (Data Transfer Objects)
// This is a class that is used to transfer data between software application subsystems.
// DTOs are often used in the context of a client-server architecture to transfer data between a client and a server.

namespace API.DTOs
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string buyerId { get; set; }

        public List<BasketItemDto> Items { get; set;}
    }
 
}