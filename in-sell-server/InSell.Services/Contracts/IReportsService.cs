using InSell.Models;
using InSell.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InSell.Services.Contracts
{
    public interface IReportsService
    {
        public Task<List<Lead>> GetLeadsReportByDate(DateTime timeFrame);

        public Task<List<Lead>> GetLeadsReportByPerson(string userId, DateTime timeFrame);

        public Task<List<UserKRA>> GetKRAReports();

        public Task<List<Lead>> GetLeadsByUserInTimeframe(string userId, DateTime startDate, DateTime endDate);

        public Task<List<Lead>> GetAllLeadsByUserInTimeframe(DateTime startDate, DateTime endDate);
    }
}
