using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Web.Models
{
    public class SalesOrder
    {

        public ResponsiblePerson ResponsiblePerson { get; set; }

        public CreditCardFlagEnum CreditCardFlag { get; set; }
   
        public String CreditCardNumber { get; set; }
   
        public String CreditCardMaskedNumber { get; set; }
   

        [Required(ErrorMessage = "{0} é obrigatório")]
        public String CreditCardHolderName { get; set; }


    }

    public enum CreditCardFlagEnum
    {
        Visa = 1,
        Mastercard = 2,
        Diners = 3,
        Hiper = 4,
        Hipercard = 5,
        JCB = 6,
        Credz = 7
    }

}
