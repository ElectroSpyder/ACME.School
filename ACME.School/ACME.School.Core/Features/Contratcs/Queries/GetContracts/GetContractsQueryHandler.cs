using ACME.School.Core.Models;
using ACME.School.Core.Persistences;
using AutoMapper;
using MediatR;

namespace ACME.School.Core.Features.Contratcs.Queries.GetContracts
{
    public class GetContractsQueryHandler : IRequestHandler<GetContractQuery, List<ContractModel>>
    {
        private readonly IContractRespository _contractRespository;
        private readonly IMapper _mapper;

        public GetContractsQueryHandler(IContractRespository contractRespository, IMapper mapper)
        {
            _contractRespository = contractRespository;
            _mapper = mapper;
        }

        public async Task<List<ContractModel>> Handle(GetContractQuery request, CancellationToken cancellationToken)
        {
            var contracts = await _contractRespository.ListAllAsync();
          
            var contractsModel = _mapper.Map<List<ContractModel>>(contracts);

            return contractsModel;
           
        }
    }
}
