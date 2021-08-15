using InSell.Models;
using InSell.Models.Response;
using InSell.Services.Contracts;
using InSell.Services.Contracts.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSell.Services.Providers
{
    public class ReportsService : IReportsService
    {
        ILeadRepository LeadRepository { get; set; }
        IUserProfileRepository UserProfileRepository { get; set; }

        public ReportsService(ILeadRepository leadRepository, IUserProfileRepository userProfileRepository)
        {
            this.LeadRepository = leadRepository;
            this.UserProfileRepository = userProfileRepository;
        }

        public async Task<List<UserKRA>> GetKRAReports()
        {
            IList<UserProfile> totalProfiles = await this.UserProfileRepository.GetItems();
            IList<Lead> totalLeads = await this.LeadRepository.GetItems();
            List<UserKRA> result = new List<UserKRA>();
            List<UserProfile> Profiles = totalProfiles.ToList();
            Profiles.ForEach(profile => result.Add(new UserKRA() {
                FirstName = profile.FirstName,
                UserProfileId = profile.Id,
                LeadsCount = 0,
                ProfilePicUrl = profile.ProfilePicUrl,
                ReportingToId = profile.ReportingToId
            }));
            result.ForEach(r => r.LeadsCount = totalLeads.Where(lead => lead.AddedBy.Id == r.UserProfileId).Count());
            return result;
        }

        public async Task<List<Lead>> GetLeadsReportByDate(DateTime timeFrame)
        {
            IList<Lead> totalLeads = await this.LeadRepository.GetItems();
            List<Lead> result = totalLeads.Where(lead =>
                (lead.AddedOn.Date == timeFrame.Date)
            ).ToList();
            return result;
        }

        public async Task<List<Lead>> GetLeadsReportByPerson(string userId, DateTime timeFrame)
        {
            IList<Lead> totalLeads = await this.LeadRepository.GetItems();
            List<Lead> result = totalLeads.Where(lead =>
                lead.AddedBy.Id == userId && lead.AddedOn.Date == timeFrame.Date
            ).ToList();
            return result;
        }

        public async Task<List<Lead>> GetLeadsByUserInTimeframe(string userId, DateTime startDate, DateTime endDate)
        {
            IList<Lead> totalLeads = await this.LeadRepository.GetItems();
            List<Lead> result = totalLeads.Where(_ => _.AddedBy.Id == userId && _.AddedOn >= startDate && _.AddedOn <= endDate).ToList();
            return result;
        }

        public async Task<List<Lead>> GetAllLeadsByUserInTimeframe(DateTime startDate, DateTime endDate)
        {
            IList<Lead> totalLeads = await this.LeadRepository.GetItems();
            List<Lead> result = totalLeads.Where(_ => _.AddedOn >= startDate && _.AddedOn <= endDate).ToList();
            return result;
        }
    }
}
