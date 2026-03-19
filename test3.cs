using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace lab3.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsLeapYear_booleanValueIsLeapYear()
        {
            Date date1 = new Date(1, 1, 2020);
            Assert.IsTrue(date1.IsLeapYear(2020));
        }
        [TestMethod]
        public void isYearValid_booleanValueIsValid()
        {
            Date date1 = new Date(1, 1, 2020);
            Assert.IsTrue(date1.IsDateValid());
        }
        [TestMethod]
        public void SortDates_arrayIsSorted()
        {
            Date date1 = new Date(1, 1, 2020);
            Date date2 = new Date(1, 1, 2019);
            Date date3 = new Date(1, 1, 2021);
            Date[] dateArray = { date1, date2, date3 };
            Date.SortDates(dateArray);
            Assert.AreEqual(date2, dateArray[0]);
            Assert.AreEqual(date1, dateArray[1]);
            Assert.AreEqual(date3, dateArray[2]);
        }
        [TestMethod]
        public void GetNumberBetween_numberOfDaysIsCorrect()
        {
            Date date1 = new Date(1, 1, 2020);
            Date date2 = new Date(21, 1, 2020);
            Assert.AreEqual(20, date1.GetNumberBetween(date2));
        }
    }
}
