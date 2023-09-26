using HRWeb.Data;
using HRWeb.Data.Entities;
using HRWeb.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRWeb.Services.Implementations
{
    public class HumanResourceService : IHumanResourceService
    {
        //private readonly IRepository _repository;

        public HumanResourceService()
        {
        }

        public async Task<Recruiter> GetRecruiterById(int id)
        {
            using var db = new HRDbContext();
            return await db.Recruiters.FirstAsync(x => x.Id == id);
        }
        public async Task<Recruiter> GetRecruiterByName(string firstName, string lastName)
        {
            using var db = new HRDbContext();
            return await db.Recruiters.FirstAsync(x => x.FirstName == firstName || x.LastName == lastName);
        }

        public async Task<Recruiter> UpsertRecruiter(Recruiter recruiter)
        {
            try
            {
                using var db = new HRDbContext();
                var existingRecruiter = await db.Recruiters.FirstAsync(x => x.Id == recruiter.Id);
                if(existingRecruiter!=null ) {
                    db.Recruiters.Add(recruiter);
                } db.Recruiters.Update(recruiter);
                await db.SaveChangesAsync();
                return recruiter;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
