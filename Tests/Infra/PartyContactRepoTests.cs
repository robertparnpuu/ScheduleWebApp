using Data;
using Domain;
using Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra
{
    [TestClass]
    public class PartyContactRepoTests : BaseRepoTests<PartyContactRepo, PartyContactData, PartyContact>
    {
    }
}