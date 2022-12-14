using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ASPNET2.Repositories
{
    public class CategoryDbRepository : ICategoryRepository
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

        public List<Category> FindAllByIdIn(List<int> ids)
        {
            List<Category> result = new List<Category>();   
            foreach(int id in ids)
                result.Add(Context.Categories.Find(id));
            return result;
        }

        public Category Create(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
            return category;
        }

        public Category Update(Category category)
        {
            if (category.Id == 0)
                return Create(category);

            // guardar solo attributes que interesen
            Context.Categories.Attach(category);
            Context.Entry(category).Property(b => b.Name).IsModified = true;
            Context.Entry(category).Property(b => b.MinAge).IsModified = true;
            Context.SaveChanges();

            return FindById(category.Id);
        }

        public List<Category> FindByMinAge(int age)
        {
            return Context.Categories
                .Where(c => c.MinAge >= age).ToList();
        }
    }
}
