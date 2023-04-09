using LaoInsur.Territories.Continents;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace LaoInsur.Continents {
    public class ContinentAppService_Tests : LaoInsurApplicationTestBase {
        private readonly IContinentAppService _continentAppService;

        public ContinentAppService_Tests() {
            _continentAppService = GetRequiredService<IContinentAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Continents() {
            //Act
            var result = await _continentAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.TotalCount.ShouldBe(7);
            //result.Items.ShouldContain(b => b.ISO2Codes == "AS");
        }

        [Fact]
        public async Task Should_Create_A_Valid_Continent() {
            //Act
            var result = await _continentAppService.CreateAsync(
                new CreateUpdateContinentDto {
                    ISO2Codes = "LA",
                    NameEng = "LA",
                    NameLao = "LA",
                    DescriptionEng = "LA",
                    DescriptionLao = "LA"
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.ISO2Codes.ShouldBe("LA");
        }

        [Fact]
        public async Task Should_Not_Create_A_Continent_With_Wrong_ISO2Codes() {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _continentAppService.CreateAsync(
                new CreateUpdateContinentDto {
                    ISO2Codes = "LAO",
                    NameEng = "LAO",
                    NameLao = "LAO",
                    DescriptionEng = "LAO",
                    DescriptionLao = "LAO"
                }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == "ISO2Codes"));
        }


    }
}
