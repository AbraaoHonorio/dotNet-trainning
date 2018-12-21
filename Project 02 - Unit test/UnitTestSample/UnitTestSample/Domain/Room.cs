using System;
using System.Collections.Generic;
using System.Text;


/* class of example only for study purposes.
    * The correct thing is that the domain should ta in another solution 
    *  the validations should be by contract(fluent validation) form not in the constructor
 */
namespace UnitTestSample.Domain
{
    public class Room
    {
        public Room(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new Exception("Nome Inválido");

            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public DateTime Book(DateTime startDate, DateTime endDate, List<DateTime> books)
        {
            if(books.Contains(startDate))
            {
                throw new Exception("sala já reservada nesse horário");
            }

            return startDate;
        }
    }
}
