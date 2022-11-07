using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET2.Repositories
{
    internal class CategoryDbRepository : ICategoryRepository
    {
        // attr
        private AppDbContext Context;
        public CategoryDbRepository(AppDbContext context)
        {
            Context = context;
        }

        // methods
        public Category FindById(int id)
        {
            return Context.Categories.Find(id);
        }
        public List<Category> FindAll()
        {
            return Context.Categories.ToList();
        }

        
        public Category Create(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
            return category;
        }

    }
}
