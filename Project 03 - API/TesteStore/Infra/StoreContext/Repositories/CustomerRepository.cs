
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TesteStore.Domain.StoreContext.Entities;
using TesteStore.Domain.StoreContext.Queries;
using TesteStore.Domain.StoreContext.Repositories;
using TesteStore.Infra.StoreContexts.DataContexts;

namespace TesteStore.Infra.StoreContexts.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TesteDataContext _context;

        public CustomerRepository(TesteDataContext context)
        {
            this._context = context;
        }

        public bool CheckDocument(string document)
        {
            return this._context.
                _Connection
                .Query<bool>(
                    "spCheckDocument",
                    new { DocumentParameter = document },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return this._context.
                     _Connection.Query<bool>("spCheckEmail", 
                                    new { EmailParameter = email },
                                    commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
          string Sql = "SELECT Id, CONCAT(FirstName, ' ', LastName) AS Name, Document, Email FROM Customer";

            return _context
                ._Connection
               .Query<ListCustomerQueryResult>(Sql, new { });

        }

        public GetCustomerQueryResult Get(Guid IdParameter)
        {
            string Sql = "SELECT Id, CONCAT(FirstName, ' ', LastName) AS Name, Document, Email FROM Customer WHERE ID = idParameter ";

            return _context
                ._Connection
               .Query<GetCustomerQueryResult>(Sql, new { id = IdParameter }).FirstOrDefault();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Customer customer)
        {

             this._context.
                    _Connection.Query<bool>("spCreateCustomer",
                    new
                    {
                        IdP = customer.Id,
                        FirstNameP = customer.Name.FirstName,
                        LastNameP = customer.Name.LastName,
                        DocumentP = customer.Document.Number,
                        EmailP = customer.Email.Address,
                        PhoneP = customer.Phone.Digits
                    },commandType: CommandType.StoredProcedure);

            foreach(var address in customer.Addresses)
            {
                this._context._Connection.Execute("spCreateAddress",
                     new
                     {
                         IdP = address.Id,
                         CustomerIdP = customer.Id,
                         NumberP = address.Number,
                         complementP = address.Complement,
                         districtP = address.District,
                         cityP = address.City,
                         state = address.State,
                         zipCodeP = address.ZipCode,
                         typeP = address.Type
                            
                     }, commandType: CommandType.StoredProcedure);
            }
        }

       
    }
}
