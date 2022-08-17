using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment4.Controllers;
using Assignment4.Data;
using Assignment4.Models;
using Xunit;

namespace Assignment4.Tests
{
    public class TeamsControllerTest : BasicTest
    {
        [Fact]
        public async Task Index_Basic_Test()
        {
            using (var testDb = new ApplicationDbContext(this._opts))
            {
                var testCtrl = new BrandsController(testDb);
                var res = await testCtrl.Index();
                var resVr = Assert.IsType<ViewResult>(res);
                Assert.IsAssignableFrom<IEnumerable<Brand>>(resVr.ViewData.Model);
            }
        }

        [Fact]
        public async Task Add_And_Remove_Test()
        {
            using (var testDb = new ApplicationDbContext(this._opts))
            {
                var testCtrl = new BrandsController(testDb);
                var fakeBrands = MakeFakeBrands(3);

                // Adding Jobs
                foreach (var brand in fakeBrands)
                {
                    var res = await testCtrl.Create(brand);
                    var resVr = Assert.IsType<RedirectToActionResult>(res);
                    Assert.Equal("Index", resVr.ActionName);
                }



                // Testing Saved Values
                var idxRes = await testCtrl.Index();
                var idxResVr = Assert.IsType<ViewResult>(idxRes);
                var returnedBrands = Assert.IsAssignableFrom<IEnumerable<Brand>>(idxResVr.ViewData.Model);
                foreach (var brand in fakeBrands)
                {
                    Assert.Contains(brand, returnedBrands);
                }



                // Removing All Existing Jobs
                foreach (var brand in returnedBrands)
                {
                    var res = await testCtrl.DeleteConfirmed(brand.Id);
                    var resVr = Assert.IsType<RedirectToActionResult>(res);
                    Assert.Equal("Index", resVr.ActionName);
                }
            }
        }
    }
}