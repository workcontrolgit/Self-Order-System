using System;
using System.Collections.Generic;
using System.Text;

namespace InstantPOS.Application.Models.Contact
{
    public class ContactResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
    }
}
