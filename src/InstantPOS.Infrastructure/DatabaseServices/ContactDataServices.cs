using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstantPOS.Application.DatabaseServices.Interfaces;
using InstantPOS.Application.MockDataServices.Interfaces;
using InstantPOS.Application.Models.Contact;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace InstantPOS.Infrastructure.DatabaseServices
{
    public class ContactDataServices : IContactDataService
    {

        private readonly IMockDataService<ContactResponseModel> _contactsGeneratorService;
        //private readonly IDatabaseConnectionFactory _database;
        //private readonly QueryFactory _db;

        public ContactDataServices(IMockDataService<ContactResponseModel> dataGeneratorService)
        {
            //_database = database;
            //_db = db;
            _contactsGeneratorService = dataGeneratorService;
        }

        public async Task<IEnumerable<ContactResponseModel>> FetchContact(int pageNo, int pageSize)
        {

            //Example of custom data
            GenFu.GenFu.Configure<ContactResponseModel>()
                .Fill(p => p.Age)
                .WithinRange(19, 25);

            IEnumerable<ContactResponseModel> contacts = await _contactsGeneratorService.Collection(10000);

            var result = contacts.Skip((pageNo - 1) * pageSize).Take(pageSize);

            return result;
        }

    }
}
