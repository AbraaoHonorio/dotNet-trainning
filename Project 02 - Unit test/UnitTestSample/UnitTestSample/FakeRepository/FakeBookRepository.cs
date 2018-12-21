using System;
using System.Collections.Generic;
using System.Text;
using UnitTestSample.Domain.Contracts;

namespace UnitTestSample.FakeRepository
{
    public class FakeBookRepository : IBookRepository
    {
        public List<DateTime> GetByDate(DateTime startDate, DateTime endDate)
        {
            List<DateTime> result = new List<DateTime>();
            result.Add(startDate);

            return result;
        }
    }
}
