using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstantPOS.Application.Models.Contact;

namespace InstantPOS.Application.DatabaseServices.Interfaces
{
    public interface IContactDataService
    {
        Task<IEnumerable<ContactResponseModel>> FetchContact(int pageNo, int pageSize);
    }
}