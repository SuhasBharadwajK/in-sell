using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InSell.Models;
using InSell.Services.Contracts;
using InSell.Services.Contracts.Infra;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace InSell.Services.Providers
{
    public class EmailService: IEmailService
    {
        ILeadRepository LeadRepository;
        IList<Lead> leads;

        public EmailService(ILeadRepository leadRepository)
        {
            this.LeadRepository = leadRepository;
            this.leads = this.LeadRepository.GetItems().Result;
        }

        private  IEnumerable<IGrouping<string, Lead>> GenerateData()
        {
            return leads.GroupBy(_ => _.AddedBy.Email);
        }

        private string GetEmailHTML(int matchedKRA, int belowKRA, int aboveKRA)
        {
            return "<body style='background-color:#d1e0e0; padding: 5% 10%;'>" +
        "<header style = 'background-color: #3385ff; padding:2%; color:white;'>" +
        "<h3 style = 'margin: 2% 5%; font-size: 1.6em;' > Daily Digest </ b ></h3>" +
        "<h3 style = 'margin: 2% 5%;font-size: 1.6em;' >" + DateTime.Now.ToString("dd / MM / yyyy") + "</h3>" +
        "</header>" +
        "<section style = 'background-color: #f2f2f2; margin: 3% 1%; padding: 3% 2%;'>" +
        "<ul>" +
        "<li style = 'margin-bottom: 10px;'> Number of leads created " + GenerateData().Count() + "</li>" +
        "<li style = 'margin-bottom: 10px;'> Number of people reached KRA " + matchedKRA + "</li>" +
        "<li style = 'margin-bottom: 10px;'> Number of people below KRA " + belowKRA + "</li>" +
        "<li style = 'margin-bottom: 10px;'> Number of people above KRA " + aboveKRA + "</li>" +
        "</ul>" +
        "</section>" +
        "</body>";
        }

        public async Task SendEmailAsync()
        {
            int belowKRA = GenerateData().Where(_ => _.Count() < 60).Count();
            int aboveKRA = GenerateData().Where(_ => _.Count() > 60).Count();
            int matchedKRA = GenerateData().Count() - (belowKRA + aboveKRA);
            try
            {
                var client = new SendGridClient("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");
                var from = new EmailAddress("amankhare1414@gmail.com", "Aman");
                var subject = "Inside Sales Daily Digest";
                var to = new EmailAddress("hitoishi.das@gmail.com", "");
                var htmlContent = GetEmailHTML(matchedKRA, belowKRA, aboveKRA);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);
                var res = await client.SendEmailAsync(msg);
                Console.WriteLine(res.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
