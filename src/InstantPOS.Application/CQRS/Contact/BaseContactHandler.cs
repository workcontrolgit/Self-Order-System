using InstantPOS.Application.DatabaseServices.Interfaces;

namespace InstantPOS.Application.CQRS.Contact
{
    public class BaseContactHandler
    {
        public readonly IContactDataService _contactDataService;
        public BaseContactHandler(IContactDataService contactDataService)
        {
            _contactDataService = contactDataService;
        }
    }
}
