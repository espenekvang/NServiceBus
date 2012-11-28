using System.Web.Mvc;
using Messages;

namespace MvcApplication1.Controllers
{
    public class QueryMessageController : Controller
    {
        public ActionResult Index()
        {
            MvcApplication.Bus.Send<Query>(m => m.NumberOfResponses = 10);
            return new ContentResult {Content = "Message sent"};
        }

    }
}
