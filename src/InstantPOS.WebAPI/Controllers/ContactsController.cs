using InstantPOS.Application.CQRS.Contact.Query;
using InstantPOS.Application.Models.Contact;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InstantPOS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]

    public class ContactsController : CustomBaseApiController
    {
        public ContactsController(IMediator mediator) : base(mediator)
        {

        }
        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<ContactResponseModel>> Get(int pageNo, int pageSize)
        {
            var query = new FetchContactQuery() { PageNo = pageNo, PageSize = pageSize };
            return await Mediator.Send(query);
        }

    }
}
