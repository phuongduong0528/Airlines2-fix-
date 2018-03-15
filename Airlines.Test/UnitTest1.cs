using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Airlines.Program.Controller;
using Airlines.Service;
using Airlines.Service.Dto;
using NUnit.Framework;

namespace Airlines.Test
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        [TestCase("2017/10/05","49",1)]
        public async Task TestMethod1(string date,string flightnumber,int expected)
        {
            ScheduleController controller = new ScheduleController();

            int id = await controller.FindFlight(date, flightnumber);

            Assert.AreEqual(id, expected);
        }
    }
}
