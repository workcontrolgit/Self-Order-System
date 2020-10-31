using System;
using System.Collections.Generic;
using InstantPOS.Application.Models.Contact;
using MediatR;

namespace InstantPOS.Application.CQRS.Contact.Query
{
    public class FetchContactQuery : IRequest<IEnumerable<ContactResponseModel>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }

    }
}