﻿using Data.Common;
namespace Data
{
    public class ContactData : BaseEntityData
    {
        public string email { get; set;  }
        public string phoneNumber {  get; set; }
        public int addressId { get; set;  }
    }
}
