using NUnit.Framework;
using System;

namespace Swin_Adventure2
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAreYou()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsTrue(id.AreYou("fred"));
            Assert.IsTrue(id.AreYou("bob"));
        }
        [Test]
        public void TestNotAreYou()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsFalse(id.AreYou("wilma"));
            Assert.IsFalse(id.AreYou("boby"));
        }
        [Test]
        public void TestCaseSensitive()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsTrue(id.AreYou("FRED"));
            Assert.IsTrue(id.AreYou("bOB"));
        }
        [Test]
        public void TestFirstIdentifier()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsTrue(Equals(id.FirstId, "fred"));
        }
        [Test]
        public void TestAddID()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            id.AddIdentifier("wilma");
            Assert.IsTrue(id.AreYou("wilma"));
        }

    }
}