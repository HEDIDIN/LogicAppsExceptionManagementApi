using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using LogManagement.Models;
using Microsoft.Ajax.Utilities;

namespace LogManagement.Controllers
{
    public class LogsController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await DocumentDbRepository<CrmRequest>.GetItemsAsync(response => response.Expired);
            return View(items);
        }


        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id)
        {
            var item = await DocumentDbRepository<CrmRequest>.GetItemAsync(id);
            return View(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = await DocumentDbRepository<CrmRequest>.GetItemAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "Id")] string id)
        {
            await DocumentDbRepository<CrmRequest>.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }
    }
}