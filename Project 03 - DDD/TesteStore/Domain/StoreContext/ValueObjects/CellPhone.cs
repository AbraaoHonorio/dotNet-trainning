using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TesteStore.Domain.StoreContext.ValueObjects
{
    public class CellPhone : Notifiable
    {
        public CellPhone(string digits)
        {
            Digits = digits;

            AddNotifications(new ValidationContract()
               .IsTrue(IsPhoneNumber(this.Digits), "Document", "Celular inválido")
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
