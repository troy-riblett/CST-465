using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465
{
    [Authorize]
    public class CategoryController : Controller
    {
        private IDataEntityRepository<CategoryData> m_categoryRepo;

        public CategoryController(IDataEntityRepository<CategoryData> repo)
        {
            m_categoryRepo = repo;
        }

        // GET: Blog
        public ActionResult Index()
        {
            List<CategoryData> list = m_categoryRepo.GetList();
            list.Sort((first, second)=> String.Compare(first.Name,second.Name));
            return View(list);
            //return View();
        }

        [HttpPost]
        public ActionResult Index(CategoryModel model, string submitButton)
        {
            if (ModelState.IsValid)
            {
                CategoryData category = new CategoryData()
                { ID = model.ID, Name = model.Name };

                if (submitButton.Equals("delete"))
                {
                    m_categoryRepo.Delete(category);
                }
                else
                {
                    m_categoryRepo.Save(category);
                }
            }
            
            return RedirectToAction("Index");
        }
    }
}