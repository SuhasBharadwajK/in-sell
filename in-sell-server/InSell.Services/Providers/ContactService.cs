using InSell.Models;
using InSell.Services.Contracts;
using InSell.Services.Contracts.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InSell.Services.Providers
{
    public class ContactService : IContactService
    {
        private IContactRepository ContactRepository { get; set; }

        public ContactService(IContactRepository contactRepository)
        {
            this.ContactRepository = contactRepository;
        }

        public void CreateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(long contactId)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetContact(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
