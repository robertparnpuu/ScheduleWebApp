using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aids;
using Data;
using Domain;
using Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class AddressEntityTests : BaseTests<Address, BaseEntity<AddressData>>
    {
        protected override Address CreateObject() => GetRandom.ObjectOf<Address>();
    }
}

