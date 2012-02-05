﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SirenOfShame.Lib.Watcher;

namespace SirenOfShame.Test.Unit.Watcher
{
    [TestClass]
    public class NewAlertArgsTest
    {
        [TestMethod]
        public void Instantiate_ThreeArgsAllGood_ReturnsTrue()
        {
            var newAlertArgs = new NewAlertArgs();
            var result = newAlertArgs.Instantiate(@"56
633979872000000000");
            Assert.IsTrue(result);
            Assert.AreEqual(56, newAlertArgs.SoftwareInstanceId);
            Assert.AreEqual("Hello World", newAlertArgs.Message);
            Assert.AreEqual("http://www.google.com", newAlertArgs.Url);
            Assert.AreEqual(new DateTime(2010, 1, 2), newAlertArgs.AlertDate);
        }
        
        [TestMethod]
        public void Instantiate_Error_ReturnsFalse()
        {
            var newAlertArgs = new NewAlertArgs();
            var result = newAlertArgs.Instantiate("Error Occurred");
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void Instantiate_ExtraArgs_Ignored()
        {
            var newAlertArgs = new NewAlertArgs();
            var result = newAlertArgs.Instantiate("56\r\nhttp://www.google.com\r\nHello World\r\n633979872000000000\r\n\r\n\r\n\r\n\r\n");
            Assert.IsTrue(result);
            Assert.AreEqual(56, newAlertArgs.SoftwareInstanceId);
            Assert.AreEqual("Hello World", newAlertArgs.Message);
            Assert.AreEqual("http://www.google.com", newAlertArgs.Url);
        }
    }
}