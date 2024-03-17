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
    }
}
