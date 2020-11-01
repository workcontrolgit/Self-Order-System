using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InstantPOS.Application.Models.Contact;
using MediatR;

namespace InstantPOS.Application.CQRS.Contact.Query
{
    public class FetchContactQuery : IRequest<IEnumerable<ContactResponseModel>>
    {
        [DefaultValue(1)]
        [Required]
        public int PageNo { get; set; }
        [DefaultValue(10)]
        [Required]
        public int PageSize { get; set; }

    }
}