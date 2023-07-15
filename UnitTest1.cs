using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using tiffin;
using Moq;

namespace TiffinTests
{
    [TestClass]
    public class KeralaTests
    {
        [TestMethod]
        public void TestKeralaCreation()
        {
            var window = new kerala();
            Assert.IsNotNull(window);
        }

        [TestMethod]
        public void TestPayNowButton_Click()
        {
            var mock = new Mock<kerala> { CallBase = true };
            mock.Object.PayNowButton_Click(null, null);
            mock.Verify(m => m.PayNowButton_Click(null, null), Times.Once());
        }

        [TestMethod]
        public void TestCallKitchenButton_Click()
        {
            var mock = new Mock<kerala> { CallBase = true };
            mock.Object.CallKitchenButton_Click(null, null);
            mock.Verify(m => m.CallKitchenButton_Click(null, null), Times.Once());
        }
    }

    [TestClass]
    public class PunjabTests
    {
        [TestMethod]
        public void TestPunjabCreation()
        {
            var window = new punjab();
            Assert.IsNotNull(window);
        }

        [TestMethod]
        public void TestPayNowButton_Click()
        {
            var mock = new Mock<punjab> { CallBase = true };
            mock.Object.PayNowButton_Click(null, null);
            mock.Verify(m => m.PayNowButton_Click(null, null), Times.Once());
        }

        [TestMethod]
        public void TestCallKitchenButton_Click()
        {
            var mock = new Mock<punjab> { CallBase = true };
            mock.Object.CallKitchenButton_Click(null, null);
            mock.Verify(m => m.CallKitchenButton_Click(null, null), Times.Once());
        }
    }
}
