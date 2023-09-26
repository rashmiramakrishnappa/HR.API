using HRWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRWeb.Services.Interfaces
{
    public interface IHumanResourceService
    {
        Task<Recruiter> GetRecruiterById(int id);
        Task<Recruiter> GetRecruiterByName(string firstName, string lastName);
        Task<Recruiter> UpsertRecruiter(Recruiter recruiter);
    }
}
