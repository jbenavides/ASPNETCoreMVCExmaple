using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class MockPieRepository : IPieRepository
    {
        private readonly ICategoryRepository _categoryRepository;

        public MockPieRepository(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Pie> Pies => new List<Pie>
        {
            new Pie{PieId = 1, Name = "Straberry pie", Price = 15.95M, ShortDescription = "blabla1", Category = _categoryRepository.Categories.FirstOrDefault(x => x.CategoryId==1)},
            new Pie{PieId = 2, Name = "Cheese cake", Price = 18.95M, ShortDescription = "blabla2", Category = _categoryRepository.Categories.FirstOrDefault(x => x.CategoryId==2)},
            new Pie{PieId = 3, Name = "Rhubarb pie", Price = 15.95M, ShortDescription = "blabla3", Category = _categoryRepository.Categories.FirstOrDefault(x => x.CategoryId==3)},
            new Pie{PieId = 4, Name = "Pumpkin pie", Price = 12.95M, ShortDescription = "blabla4", Category = _categoryRepository.Categories.FirstOrDefault(x => x.CategoryId==1)}
        };

        public IEnumerable<Pie> PiesOfTheWeek { get; }
        public Pie GetPieById(int pieId)
        {
            throw new NotImplementedException();
        }
    }
}
