using InSell.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InSell.Services.Contracts
{
    public interface IPracticeService
    {
        Practice GetPractice(long practiceId);

        void CreatePractice(Practice practice);

        void UpdatePractice(Practice practice);

        void DeletePractice(long practiceId);
    }
}
