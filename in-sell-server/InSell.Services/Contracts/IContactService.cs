using InSell.Models;
using System.Threading.Tasks;

namespace InSell.Services.Contracts
{
    public interface IContactService
    {
        Task<Contact> GetContact(string id);

        void CreateContact(Contact contact);

        void UpdateContact(Contact contact);

        void DeleteContact(long contactId);
    }
}
