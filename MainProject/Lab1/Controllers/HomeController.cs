using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465
{
    public class HomeController : Controller
    {
        private IDataEntityRepository<BlogPost> m_blogPostRepo;
        private IDataEntityRepository<Product> m_productRepo;

        public HomeController(IDataEntityRepository<BlogPost> repo, IDataEntityRepository<Product> productRepo)
        {
            m_blogPostRepo = repo;
            m_productRepo = productRepo;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<Product> productList = m_productRepo.GetList();
            List<BlogPost> blogList = m_blogPostRepo.GetList();

            HomePageContainer model = new HomePageContainer()
            {
                BlogList = blogList.OrderByDescending(i => i.Timestamp).Take(3).ToList(),
                ProductList = productList.Take(5).ToList()
            };

            return View(model);
        }

        [Authorize]
        public ActionResult Admin()
        {
            return View();
        }
    }
}