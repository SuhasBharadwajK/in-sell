using InSell.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InSell.Services.Contracts
{
    public interface ILeadService
    {
        Task<Lead> GetLead(string leadId);

        Task<IList<Lead>> GetLeadsByContactDetails(Contact contact, string companyId);

        Task<IList<Lead>> GetAllLeads();

        Task<Lead> CreateLead(Lead lead);

        void UpdateLead(string id, Lead lead);

        void DeleteLead(long leadId);
    }
}
