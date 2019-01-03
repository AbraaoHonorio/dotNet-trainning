using Solid.Models;



namespace Solid.DIP.Contracts
{
   public interface ICustomerRepository
    {
        void Save( Customer customer);
    }
}
