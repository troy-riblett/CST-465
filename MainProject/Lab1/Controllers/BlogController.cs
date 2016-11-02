using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465
{
    public class BlogController : Controller
    {
        private IDataEntityRepository<BlogPost> m_blogPostRepo;

        public BlogController()
        {
            m_blogPostRepo = new BlogDBRepository();
        }

        // GET: Blog
        public ActionResult Index()
        {
            return View(m_blogPostRepo.GetList());
            //return View();
        }

        public ActionResult Add()
        {
            return View(new BlogPostModel());
        }

        [HttpPost]
        public ActionResult Add(BlogPostModel model)
        {
            if (ModelState.IsValid)
            {
                BlogPost post = new BlogPost()
                { Author = model.Author, Content = model.Content, Title = model.Title, Timestamp = DateTime.Now, ID=0 };

                m_blogPostRepo.Save(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            BlogPost post = m_blogPostRepo.Get(id);

            BlogPostModel model = new BlogPostModel() { Author = post.Author, Content = post.Content, ID = post.ID, Title = post.Title };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BlogPostModel model)
        {
            if (ModelState.IsValid)
            {
                BlogPost post = new BlogPost()
                {
                    Author = model.Author,
                    Content = model.Content,
                    ID = model.ID,
                    Title = model.Title,
                    Timestamp = DateTime.Now
                };
                m_blogPostRepo.Save(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        
    }
}