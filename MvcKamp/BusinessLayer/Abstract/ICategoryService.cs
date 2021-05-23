using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAdd(Category p);
        Category GetByID(int id);//buraya Irepository ve GenericRepo dan geldik buradan da manager
        void CategoryDelete(Category p);//silmek için imzayı attık içini doldurmak için manager a gidiyoruz

        void CategoryUpdate(Category p);//güncellemek için ilk önce buraya imzaladık manager a gittik
    }
}
