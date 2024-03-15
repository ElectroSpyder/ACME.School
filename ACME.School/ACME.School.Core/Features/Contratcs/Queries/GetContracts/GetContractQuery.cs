using ACME.School.Core.Models;
using MediatR;

namespace ACME.School.Core.Features.Contratcs.Queries.GetContracts
{
    public class GetContractQuery : IRequest<List<ContractModel>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
