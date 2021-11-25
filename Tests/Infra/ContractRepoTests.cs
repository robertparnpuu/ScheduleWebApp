using System;
using System.Linq;
using Data;
using Domain;
using Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra
{
    [TestClass]
    public class ContractRepoTests : BaseRepoTests<ContractRepo, ContractData, Contract> {}
}
