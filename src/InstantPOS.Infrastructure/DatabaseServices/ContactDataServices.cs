using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstantPOS.Application.DatabaseServices.Interfaces;
using InstantPOS.Application.Models.Contact;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace InstantPOS.Infrastructure.DatabaseServices
{
    public class ContactDataServices : IContactDataService
    {

        private readonly IDataGeneratorService<ContactResponseModel> _contactsGeneratorService;
        //private readonly IDatabaseConnectionFactory _database;
        //private readonly QueryFactory _db;

        public ContactDataServices(IDataGeneratorService<ContactResponseModel> dataGeneratorService)
        {
            //_database = database;
            //_db = db;
            _contactsGeneratorService = dataGeneratorService;
        }

        public async Task<IEnumerable<ContactResponseModel>> FetchContact(int pageNo, int pageSize)
        {

            var result = await _contactsGeneratorService.Collection(10000);

            return result;
        }

    }
}
