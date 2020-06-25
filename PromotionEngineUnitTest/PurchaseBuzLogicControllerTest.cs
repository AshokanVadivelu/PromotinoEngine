using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserProfile.Controllers.Purchase;
using UserProfile.Models;
using Moq;
using System.Web.Mvc;

namespace PromotionEngineUnitTest
{
    [TestClass]
    public class PurchaseControllerTest
    {

        #region LocalVariable
        PurchaseBuzLogicController _testPurchaseBuzLogicController;
        string nullRefException = "Object reference not set to an instance of an object.";

        SkuModel model;
        #endregion
        [TestInitialize]
        public void TestInitalize()
        {
            this._testPurchaseBuzLogicController = new PurchaseBuzLogicController();
            this.model = new SkuModel
            {
                ProductAcount = 4,
                ProductBcount = 3,
                ProductCcount = 2,
                ProductDcount = 1
            };
        }

        [TestMethod]
        public void Test_GetTotal_Expected_Result()
        {
            SkuModel resultModel = (SkuModel)_testPurchaseBuzLogicController.GetTotal(model).Data;
            var expected = new SkuModel
            {
                ProductAprice = 180,
                ProductBprice = 75,
                ProductCprice = 40,
                ProductDprice = 15
            };
            Assert.AreEqual(expected.Total, resultModel.Total);
        }

        [TestMethod]
        public void Test_GetTotal_Throw_Exception()
        {
            this.model = null;
            
            NullReferenceException ex = Assert.ThrowsException<NullReferenceException>(() => _testPurchaseBuzLogicController.GetTotal(model));
            AssertFailedException.Equals(ex.Message, nullRefException);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            this._testPurchaseBuzLogicController = null;
            this.model = null;
        }
    }


}
