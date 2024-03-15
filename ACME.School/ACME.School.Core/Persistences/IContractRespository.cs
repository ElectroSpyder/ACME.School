using ACME.School.Core.Domain.Entities;

namespace ACME.School.Core.Persistences
{
    public interface IContractRespository : IAsyncRepository<Contract>
    {
        Task<List<Contract>> GetAllContractsInRangeDate(DateTime startDate, DateTime endDate);
    }
}
