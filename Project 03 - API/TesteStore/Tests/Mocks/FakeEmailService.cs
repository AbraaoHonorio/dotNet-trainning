using TesteStore.Domain.StoreContext.Services;

namespace Tests.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}
