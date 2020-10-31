using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.Contact.Query;
using InstantPOS.Application.DatabaseServices.Interfaces;
using InstantPOS.Application.Models.Contact;
using MediatR;

namespace InstantPOS.Application.CQRS.Contact.QueryHandler
{
    public class FetchContactQueryHandler : BaseContactHandler, IRequestHandler<FetchContactQuery, IEnumerable<ContactResponseModel>>
    {
        public FetchContactQueryHandler(IContactDataService contactDataService) : base(contactDataService)
        {
        }
        public async Task<IEnumerable<ContactResponseModel>> Handle(FetchContactQuery request, CancellationToken cancellationToken)
        {
            var result = await _contactDataService.FetchContact(request.PageNo, request.PageSize);

            return result;
        }
    }
}
