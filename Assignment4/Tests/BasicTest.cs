using Microsoft.EntityFrameworkCore;
using Assignment4.Data;
using Assignment4.Models;


namespace Assignment4.Tests
{
    public class BasicTest
    {
        protected readonly DbContextOptions<ApplicationDbContext> _opts;

        public BasicTest()
        {
            _opts = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestTeamCtrllr").Options;
        }



        protected List<Brand> MakeFakeBrands(int i)
        {
            var brands = new List<Brand>();
            for (int j = 0; j < i; j++)
            {
                brands.Add(new Brand
                {
                    Name = $"test{j}",
                    CompanyLocation = $"testsec{j}",
                    Owner = $"testthree{j}",
                    Products = new List<Product>()
                });
            }
            return brands;
        }





    }
}