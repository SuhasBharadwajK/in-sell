using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InSell.Services.Contracts
{
    public interface IEmailService
    {
        Task SendEmailAsync();
    }
}
