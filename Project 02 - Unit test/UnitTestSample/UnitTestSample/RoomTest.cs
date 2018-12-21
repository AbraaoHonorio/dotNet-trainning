using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UnitTestSample.Domain;
using UnitTestSample.Domain.Contracts;
using UnitTestSample.FakeRepository;

namespace UnitTestSample
{
    [TestClass]
    public class RoomTest
    {
        [TestMethod]
        [TestCategory("Nova Sala")]
        public void NomeDeveSerSala1()
        {
            var room = new Room("Sala 1");
            Assert.AreEqual("Sala 1", room.Name);
        }


        [TestMethod]
        [TestCategory("Nova Sala")]
        [ExpectedException(typeof(Exception))]
        public void NomeNaoPodeSerNulo()
        {

            var room = new Room(""); // or null

        }

        [TestMethod]
        [TestCategory("Reserva Sala")]
        [ExpectedException(typeof(Exception))]
        public void SalaDeveEstarDisponivel()
        {
            IBookRepository repFake = new FakeBookRepository();
            var startDate = DateTime.Now.AddHours(1);
            var endDate = DateTime.Now.AddHours(3);
            var room = new Room("Sala X");
            room.Book(startDate,
                      endDate,
                      repFake.GetByDate(startDate,endDate));

        }

        [TestMethod]
        [TestCategory("Reserva Sala")]
        public void SalaDeveSerReservadaComSucesso()
        {
            IBookRepository repFake = new FakeBookRepository();
            var startDate = DateTime.Now.AddHours(1);
            var endDate = DateTime.Now.AddHours(3);
            var room = new Room("Sala X");
            room.Book(startDate,
                      endDate,
                      new List<DateTime>());

        }
    }
}
