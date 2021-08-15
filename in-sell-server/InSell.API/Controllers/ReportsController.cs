using InSell.Models;
using InSell.Models.Response;
using InSell.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InSell.API.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reportService;

        public ReportsController(IReportsService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("getAllByDate")]
        public Task<List<Lead>> GetLeadsReportByDate([FromQuery] DateTime timeFrame)
        {
            return _reportService.GetLeadsReportByDate( timeFrame);
        }

        [HttpGet("getByDate")]
        public Task<List<Lead>> GetLeadsReportByPerson([FromQuery] string userId, [FromQuery] DateTime timeFrame)
        {
            return _reportService.GetLeadsReportByPerson(userId, timeFrame);
        }

        [HttpGet("getAllByTimeFrame")]
        public Task<List<Lead>> GetLeadsByUserIdByTimeframe([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            return _reportService.GetAllLeadsByUserInTimeframe(startDate, endDate);
        }

        [HttpGet("getByTimeFrame")]
        public Task<List<Lead>> GetLeadsByUserIdByTimeframe([FromQuery] string userId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            return _reportService.GetLeadsByUserInTimeframe(userId, startDate, endDate);
        }

        [HttpGet]
        public Task<List<UserKRA>> GetKRAReports()
        {
            return _reportService.GetKRAReports();
        }

    }
}