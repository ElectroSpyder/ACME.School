using ACME.School.Core.Domain.Context;
using ACME.School.Core.Domain.Entities;
using ACME.School.Core.Persistences;
using Microsoft.EntityFrameworkCore;

namespace ACME.School.Core.Repositories
{
    public class ContractRepository : BaseRepository<Contract>, IContractRespository
    {
        public ContractRepository(SqlDbContext context) : base(context)
        {
            
        }

        public async Task<List<Contract>> GetAllContractsInRangeDate(DateTime startDate, DateTime endDate)
        {
            var contracts = await _context.Contracts
                .Where(c => c.InscriptionDate >= startDate && c.InscriptionDate <= endDate).ToListAsync();
            return contracts;
        }
    }
}
