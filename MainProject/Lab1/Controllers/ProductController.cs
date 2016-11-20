using System;
using System.Collections.Generic;
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
            //list.Sort((first, second) => String.Compare(first.Name, second.Name));

            List<ProductModel> modelList = new List<ProductModel>();

            foreach(Product product in list)
            {
                modelList.Add(new ProductModel()
                {
                    CategoryName = product.CategoryName,
                    Code = product.Code,
                    Description = product.Description,
                    ID = product.ID,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity
                });
            }

            return View(modelList);
        }

        [Authorize]
        // Privileged access
        public ActionResult Add(ProductModel model)
        {
            List<CategoryData> list = m_categoryRepo.GetList();
            list.Sort((first, second) => String.Compare(first.Name, second.Name));
            //Tuple<ProductModel, List<CategoryData>> newModel = new Tuple<ProductModel, List<CategoryData>>(model, list);
            //return View(newModel);

            ViewData["Categories"] = list;
            return View(model);
        }

        [Authorize]
        // Privileged access
        public ActionResult Edit(ProductModel model)
        {
            List<CategoryData> list = m_categoryRepo.GetList();
            list.Sort((first, second) => String.Compare(first.Name, second.Name));
            //Tuple<ProductModel, List<CategoryData>> newModel = new Tuple<ProductModel, List<CategoryData>>(model, list);
            //return View(newModel);

            ViewData["Categories"] = list;
            return View(model);
        }

        [Authorize]
        public ActionResult Delete(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                Product post = new Product()
                {
                    CategoryName = model.CategoryName,
                    Code = model.Code,
                    Description = model.Description,
                    ID = model.ID,
                    Name = model.Name,
                    Price = model.Price,
                    Quantity = model.Quantity
                };

                m_productRepo.Delete(post);
                
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Save(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                Product post = new Product()
                { CategoryName = model.CategoryName, Code = model.Code,
                    Description = model.Description, ID = model.ID, Name = model.Name, Price = model.Price,
                    Quantity = model.Quantity};

                m_productRepo.Save(post);
                return RedirectToAction("Index");
            }
            else
            {
                List<CategoryData> list = m_categoryRepo.GetList();
                list.Sort((first, second) => String.Compare(first.Name, second.Name));
                ViewData["Categories"] = list;

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
            //list.Sort((first, second) => String.Compare(first.Name, second.Name));
            return View(list);
        }

        //Open to end users
        public ActionResult DisplayOne(Product product)
        {
            return View(product);
        }
    }
}