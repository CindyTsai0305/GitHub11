using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace eHR.Test
{
    [TestClass]
    public class CommonToolTest
    {
        [TestMethod]
        public void StringMaskTool()
        {
            //Arrange
            string maskString;
            //Act
            maskString = eHR.Common.StringTool.MaskString("*", 5);
            //Assert
            Assert.AreEqual(maskString, "*****");
        }
    }
}