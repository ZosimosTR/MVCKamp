using System;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category p)
        {
            _categoryDal.Insert(p);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.CategoryId == id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

         


    }
}
