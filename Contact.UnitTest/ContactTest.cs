using Contact.MvcUI.Controllers;
using System.Web.Mvc;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contact.UnitTest
{
    [TestClass]
    public class ContactTest
    {
        [TestMethod]
        public void TestMethod1()
        {


            // Arrange
            var controller = new ContactController();
            // Act
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
           // Assert.IsNotNull(result);
        }
    }
}
