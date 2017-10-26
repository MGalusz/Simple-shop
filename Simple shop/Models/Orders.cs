using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple_shop.Models
{
    public class Orders
    {
        public int OrdersId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Coments { get; set; }
        public DateTime AddDate { get; set; }
        public OrderState OrderState { get; set; }
        public decimal OrderValue { get; set; }

        private List<PositionOrder> positionOrder { get; set; }
    }

    public enum OrderState
    {
        Nowe,
        Zrealizowane
    }
}