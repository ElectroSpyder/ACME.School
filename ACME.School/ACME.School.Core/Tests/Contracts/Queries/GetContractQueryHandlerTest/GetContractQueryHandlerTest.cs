using ACME.School.Core.Features.Contratcs.Queries.GetContracts;
using ACME.School.Core.Models;
using ACME.School.Core.Persistences;
using ACME.School.Core.Profiles;
using ACME.School.Core.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using Xunit;

namespace ACME.School.Core.Tests.Contracts.Queries.GetContractQueryHandlerTest
{
    public class GetContractQueryHandlerTest
    {
        private readonly Mock<IContractRespository> _contractRespository;
        private readonly IMapper _mapper;

        public GetContractQueryHandlerTest()
        {
            _contractRespository = RepositoryMock.GetContractRespository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetAllContract()
        {
            var handler = new GetContractsQueryHandler(_contractRespository.Object, _mapper);
            var result = await handler.Handle(new GetContractQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<ContractModel>>();

            result.Count.ShouldBe(1);

        }
    }
}
