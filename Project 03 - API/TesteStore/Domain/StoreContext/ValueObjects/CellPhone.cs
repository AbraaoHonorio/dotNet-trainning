using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TesteStore.Domain.StoreContext.ValueObjects
{
    public class CellPhone : Notifiable
    {
        public CellPhone(string digits)
        {
            Digits = new String(digits.Where(Char.IsDigit).ToArray());

            AddNotifications(new ValidationContract()
               .IsTrue(IsPhoneNumber(digits), "Document", "Celular inválido")
           );
        }

        public string Digits {get; private set;}

        public bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$$").Success;
        }
        public override string ToString()
        {
            return Digits;
        }

    }
}
