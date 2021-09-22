using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aids;
using Data;
using Domain;
using Domain.Common;
using Tests;

namespace Tests.Domain
{
    [TestClass]
    public class AddressEntityTests:SealedClassTests<Address,BaseEntity<AddressData>>
    {
        protected override Address GetObject() => GetRandom.ObjectOf<Address>();
    }
}