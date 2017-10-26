using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Simple_shop.Models
{
    public class Orders
    {
        public int OrdersId { get; set; }
        [Required(ErrorMessage = "Wprowadz Imię")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Wprowadz Nazwisko")]
        [StringLength(100)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Wprowadz Ulicę")]
        [StringLength(100)]
        public string Street { get; set; }
        [Required(ErrorMessage = "Wprowadz Miasto")]
        [StringLength(100)]
        public string City { get; set; }
        [Required(ErrorMessage = "Wprowadz kod pocztowy")]
        [StringLength(6)]
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