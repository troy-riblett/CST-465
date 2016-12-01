using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465
{
    public class ProductController : Controller
    {
        private IDataEntityRepository<Product> m_productRepo;
        private IDataEntityRepository<CategoryData> m_categoryRepo;

        public ProductController(IDataEntityRepository<Product> repo, IDataEntityRepository<CategoryData> categoryRepo)
        {
            m_productRepo = repo;
            m_categoryRepo = categoryRepo;
        }

        [Authorize]
        // Privileged access, since this one will allow editing
        public ActionResult Index()
        {
            List<Product> list = m_productRepo.GetList();

            return View(list);
        }

        [Authorize]
        // Privileged access
        public ActionResult Add(ProductModel model)
        {
            List<CategoryData> list = m_categoryRepo.GetList();
            list.Sort((first, second) => String.Compare(first.Name, second.Name));

            model.AvailableCategories = list;

            return View(model);
        }

        [Authorize]
        // Privileged access
        public ActionResult Edit(ProductModel model)
        {
            List<CategoryData> list = m_categoryRepo.GetList();
            list.Sort((first, second) => String.Compare(first.Name, second.Name));

            model.AvailableCategories = list;

            return View(model);
        }

        [Authorize]
        public ActionResult Delete(int ID)
        {
            Product product = m_productRepo.Get(ID);

            if (product != null)
            {
                m_productRepo.Delete(product);
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Save(ProductModel model)
        {
            if (ModelState.IsValid && model.Image != null) // && model.Image.ContentLength < 50000)
            {
                Product post = new Product()
                {
                    CategoryName = model.CategoryName,
                    Code = model.Code,
                    Description = model.Description,
                    ID = model.ID,
                    Name = model.Name,
                    Price = model.Price,
                    Quantity = model.Quantity,
                };

                using (var memoryStream = new MemoryStream())
                {
                    model.Image.InputStream.CopyTo(memoryStream);
                    post.FileData = memoryStream.ToArray();
                }

                m_productRepo.Save(post);
                return RedirectToAction("Index");
            }
            else
            {
                List<CategoryData> list = m_categoryRepo.GetList();
                list.Sort((first, second) => String.Compare(first.Name, second.Name));

                model.AvailableCategories = list;

                if (model.ID == 0)
                {
                    return View("Add", model);
                }
                else
                {
                    return View("Edit", model);
                }
            }
        }

        //Open to end users
        public ActionResult Display()
        {
            List<Product> list = m_productRepo.GetList();

            return View(list);
        }

        //Open to end users
        public ActionResult DisplayOne(int ID)
        {
            Product product = m_productRepo.Get(ID);

            if (product != null)
            {
                return View(product);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}