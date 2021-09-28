﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aids;
using Data;
using Domain;
using Domain.Common;
using Tests;

namespace Tests.Domain
{
    [TestClass]
    public class AddressEntityTests:BaseTests<Address,BaseEntity<AddressData>>
    {
        protected override Address CreateObject() => GetRandom.ObjectOf<Address>();
        [TestMethod]
        public void ApartmentNumberTest() => IsProperty<string>(nameof(obj.apartmentNumber));
    }
}