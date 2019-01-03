using Solid.DIP.Contracts;
using Solid.Models;

namespace Solid.DIP
{
    public class CustomerService
    {
        private ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public void Register(Customer customer)
        {
            this._repository.Save(customer);
        }
    }
}
