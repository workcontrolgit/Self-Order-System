using InstantPOS.Application.CQRS.Contact.Query;
using InstantPOS.Application.Models.Contact;
using InstantPOS.WebAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// <summary>
        /// Gets all folders.
        /// </summary>
        /// <param name="pageNo">
        /// Required account ID.
        /// </param>
        [Description("description 1")]
        [HttpGet]
        [SwaggerParameter("pageNo", "Page number to display", DataType = "integer", ParameterType = "query")]
        [SwaggerParameter("pageSize", "Items to display per page", DataType = "integer", ParameterType = "query")]
        public async Task<IEnumerable<ContactResponseModel>> Get(int pageNo, int pageSize)
        {
            var query = new FetchContactQuery() { PageNo = pageNo, PageSize = pageSize };
            return await Mediator.Send(query);
        }

    }
}
