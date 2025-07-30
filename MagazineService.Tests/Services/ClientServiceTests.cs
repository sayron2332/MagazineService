using Xunit;
using Moq;
using MagazineService.Core.Entites;
using MagazineService.Core.Interfaces;
using AutoMapper;
using MagazineService.Core.Dtos.Client;
using MagazineService.Core.Specification;
using MagazineService.Core.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Xunit.Sdk;
using static MagazineService.Core.Specification.ClientSpecification;


namespace MagazineService.Tests.Services
{
    public class ClientServiceTests
    {
        private readonly Mock<IRepository<AppClient>> _repoMock;
        private readonly Mock<IMapper> _mapper;
        private readonly ClientService _clientService;
        public ClientServiceTests()
        {
            _repoMock = new Mock<IRepository<AppClient>>();
            _mapper = new Mock<IMapper>();
            _clientService = new ClientService(_repoMock.Object, _mapper.Object);
        }
        [Fact]
        public async Task GetCustomersWithBirthday_ReturnsMappedClients()
        {
            var date = new DateTime(2000, 1, 1);
            var clients = new List<AppClient>
            {
                new AppClient { Id = 1, Name = "John", Surname = "Doe", MiddleName = "Harriten", BirthdayDate = date },
                new AppClient { Id = 2, Name = "Jane", Surname = "Smith", MiddleName = "Rarriten", BirthdayDate = date }
            };

            _repoMock.Setup(r => r.GetListBySpec(It.IsAny<GetByDate>()))
                .ReturnsAsync(clients);

            _mapper.Setup(m => m.Map<ClientDto>(It.IsAny<AppClient>()))
                .Returns((AppClient c) => new ClientDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Surname = c.Surname,
                    MiddleName = c.MiddleName
                });

            var result = await _clientService.GetCustommersWithBirthday(date);
            Assert.NotNull(result);
            var resultList = result.ToList();
            Assert.Equal(clients.Count, resultList.Count);

            for (int i = 0; i < resultList.Count; i++)
            {
                Assert.Equal(clients[i].Id, resultList[i].Id);
                Assert.Equal(clients[i].Name, resultList[i].Name);
                Assert.Equal(clients[i].Surname, resultList[i].Surname);
                Assert.Equal(clients[i].MiddleName, resultList[i].MiddleName);
            }

            _repoMock.Verify(r => r.GetListBySpec(It.IsAny<GetByDate>()), Times.Once);
        }
        [Fact]
        public async Task GetLastCustomersByDayOrder_ReturnsClientsWithLatestOrderDate() {
            int day = 7;
            var today = new DateTime(2025, 07, 30);

            List<AppClient> clients = new List<AppClient>
            {
                new AppClient
                {
                    Id = 1,
                    Name = "Іван",
                    Surname = "Іванов",
                    MiddleName = "Іванович",
                    AppOrders = new List<AppOrder>
                    {
                        new AppOrder { DateOrder = today.AddDays(-2) },
                        new AppOrder { DateOrder = today.AddDays(-5) }
                    }
                },
                new AppClient
                {
                    Id = 2,
                    Name = "Петро",
                    Surname = "Петренко",
                    MiddleName = "Петрович",
                    AppOrders = new List<AppOrder>
                    {
                        new AppOrder { DateOrder = today.AddDays(-1) }
                    }
                }
            };

            _repoMock.Setup(r => r.GetListBySpec(It.IsAny<GetByDay>()))
           .ReturnsAsync(clients.Select(c => new ClientAndDateDto
           {
               Id = c.Id,
               FullName = $"{c.Name} {c.Surname} {c.MiddleName}",
               Date = c.AppOrders
                      .Where(o => o.DateOrder >= DateTime.Now.AddDays(-day))
                      .Max(o => o.DateOrder)
           }).ToList());

            var result = await _clientService.GetLastCustomersByDayOrder(day);
          
            var resultList = result.ToList();
            Assert.Equal(resultList.Count, clients.Count);
            Assert.NotNull(result);

            for (int i = 0; i < resultList.Count; i++)
            {
                var expectedDate = clients[i].AppOrders
                   .Where(o => o.DateOrder >= today.AddDays(-day))
                   .Max(o => o.DateOrder);

                Assert.Equal(clients[i].Id, resultList[i].Id);
                Assert.Equal($"{clients[i].Name} {clients[i].Surname}" +
                    $" {clients[i].MiddleName}", resultList[i].FullName);
                Assert.Equal(expectedDate, resultList[i].Date);

            }
            _repoMock.Verify(r => r.GetListBySpec(It.IsAny<GetByDay>()), Times.Once);
        }

    }
}
