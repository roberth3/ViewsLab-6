using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ViewsLab.Domain;
using ViewsLab.Models;

namespace ViewsLab.Controllers
{
    public class UserController : Controller
    {
        IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /User/

        public ActionResult Index(string pageSize, string page, string sort)
        {
            // TODO: complete this method
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            ViewBag.Sort = sort;
            return View();
        }

        public ActionResult UserGrid(string pageSize, string page, string sort)
        {
            // Convert pageSize and page to integers, setting a default value is they are not convertable
            int pSize;
            if (!int.TryParse(pageSize, out pSize))
            {
                pSize = 5;
            }

            int p;
            if (!int.TryParse(page, out p))
            {
                p = 0;
            }

            //Get the user collection
            IEnumerable<User> user = repository.Get(pSize, p, sort);

            //Construct the viewModel
            UserGridModel gridModel = new UserGridModel
            {
                Users = user,
                PageSize = pSize,
                CurrentPage = p,
                RowCount = repository.Count()
            };
            
            return PartialView(gridModel);
        }

        public ActionResult UserDetail(string username)
        {
            ViewBag.Username = username;
            return View();
        }
  
    }
}
