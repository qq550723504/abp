using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.ApiResources.Dtos;
using Xunit;

namespace Volo.Abp.IdentityServer
{
    public class ApiResourceAppService_Tests : AbpIdentityServerApplicationTestBase
    {
        private readonly IApiResourceAppService _apiResourceAppService;
        private readonly IApiResourceRepository _apiResourceRepository;
        public ApiResourceAppService_Tests()
        {
            _apiResourceAppService = GetRequiredService<IApiResourceAppService>();
            _apiResourceRepository = GetRequiredService<IApiResourceRepository>();
        }

        [Fact]
        public async Task GetAsync()
        {
            var targetApiResource = (await _apiResourceRepository.GetListAsync()).First();

            targetApiResource.ShouldNotBeNull();
            targetApiResource.Name.ShouldBe(targetApiResource.Name);
        }

        [Fact]
        public async Task GetListAsync()
        {
            var apiResources = await _apiResourceRepository.GetListAsync();

            apiResources.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateAsync()
        {
            //Arrange

            var input = new ApiResourceDto
            {
                Name = Guid.NewGuid().ToString("N").Left(8)
            };

            //Act

            var result = await _apiResourceAppService.CreateAsync(input);

            //Assert

            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe(input.Name);

            var role = await _apiResourceAppService.GetAsync(result.Id);
            role.Name.ShouldBe(input.Name);

        }

        [Fact]
        public async Task UpdateAsync()
        {
            var newDescription = "new description";

            var oldApiResource = (await _apiResourceRepository.GetListAsync()).FirstOrDefault(); ;

            await _apiResourceAppService.UpdateAsync(oldApiResource.Id, new ApiResourceDto()
            { Description = newDescription, DisplayName = oldApiResource.DisplayName });

            UsingDbContext(context =>
            {
                var blog = context.ApiResources.FirstOrDefault(q => q.Id == oldApiResource.Id);
                blog.Description.ShouldBe(newDescription);
            });
        }

        [Fact]
        public async Task DeleteAsync()
        {
            //Arrange

            var moderator = (await _apiResourceRepository.GetListAsync()).First();

            //Act

            await _apiResourceAppService.DeleteAsync(moderator.Id);

            //Assert

            (await _apiResourceAppService.GetAsync(moderator.Id)).ShouldBeNull();
        }
    }
}
