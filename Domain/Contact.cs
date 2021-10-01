using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Domain.Common;

namespace Domain
{
    public class Contact : BaseEntity<ContactData>
    {
        public string Email
        {
            get => default;
            set
            {
            }
        }

        public string PhoneNumber
        {
            get => default;
            set
            {
            }
        }

        public Address Aadress
        {
            get => default;
            set
            {
            }
        }
    }
}