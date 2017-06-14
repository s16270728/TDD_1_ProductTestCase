using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatisticsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsLib.Tests
{
    [TestClass()]
    public class StatisticsTests
    {
        /// <summary>
        /// Product class for testcase
        /// </summary>
        private class Product
        {
            public int Id { get; set; }
            public int Cost { get; set; }
            public int Revenue { get; set; }
            public int SellPrice { get; set; }
        }

        /// <summary>
        /// Get Sample products
        /// </summary>
        /// <returns></returns>
        private List<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product(){ Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
                new Product(){ Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
                new Product(){ Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
                new Product(){ Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
                new Product(){ Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
                new Product(){ Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
                new Product(){ Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
                new Product(){ Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
                new Product(){ Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
                new Product(){ Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
                new Product(){ Id = 11, Cost = 11, Revenue = 21, SellPrice = 31}
            };

            return products;
        }

        /// <summary>
        /// 該11筆資料，如果要3筆成一組，取得Cost的總和的話，預期結果是 6,15, 24, 21
        /// </summary>
        [TestMethod()]
        public void GroupSumTest_GroupSize_3_Products_Cost_return_6_15_24_21()
        {
            //arrange
            var target = new Statistics();
            var product = GetProducts();

            var expected = new List<int>() { 6, 15, 24, 21 };

            //act
            var actual = target.GroupSum<Product>(3, product, c => c.Cost).ToList();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 該11筆資料，如果是4筆一組，取得 Revenue 總和的話，預期結果會是 50,66,60
        /// </summary>
        [TestMethod()]
        public void GroupSumTest_GroupSize_4_Products_Revenue_return_50_66_60()
        {
            //arrange
            var target = new Statistics();
            var product = GetProducts();

            var expected = new List<int>() { 50, 66, 60 };

            //act
            var actual = target.GroupSum<Product>(4, product, c => c.Revenue).ToList();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 筆數輸入負數，預期會拋 ArgumentException
        /// </summary>
        [TestMethod()]
        public void GroupSumTest_GroupSize_Less_Than_1_Throw_ArgumentException()
        {
            //arrange
            var target = new Statistics();
            var product = GetProducts();

            //act
            Action actual = () => target.GroupSum<Product>(-1, product, c => c.Id).ToList();

            //assert
            actual.ShouldThrow<ArgumentException>();
        }

        /// <summary>
        /// 筆數若輸入為0, 則傳回0
        /// </summary>
        //[TestMethod()]
        //public void GroupSumTest_GroupSize_Equal_0_Return_0()
        //{
        //    //arrange
        //    var target = new Statistics();
        //    var product = GetProducts();

        //    var expected = new List<int>() { 0 };

        //    //act
        //    var actual = target.GroupSum<Product>(0, product, c => c.Id).ToList();

        //    //assert
        //    CollectionAssert.AreEqual(expected, actual);
        //}

        //尋找的欄位若不存在，預期會拋 ArgumentException  ==> 此function不用做此測試
        //未來可能會新增其他欄位 ==> 根據傳入的類別決定有多少欄位可以用selctor
        //希望這個API可以給其他 domain entity 用，例如 Employee ==> 可給各類別使用

    }
}