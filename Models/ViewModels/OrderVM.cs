using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vidly.Models.ViewModels
{
    public class OrderVM
    {
        public OrderHeader OrderHeader { get; set; }
        public IEnumerable<OrderDetail> OrderDetail { get; set; }
    }
}