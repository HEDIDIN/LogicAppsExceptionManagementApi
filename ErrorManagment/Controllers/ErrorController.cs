using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ErrorManagment.Models;

namespace ErrorManagment.Controllers
{
    public class ErrorController : Controller
    {
      
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await DocumentDbRepository<CrmErrorResponse>.GetItemsAsync(response => response.IsError);
            return View(items);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(
            [Bind(Include = "Id,prescriberId,notes,resolved")] CrmErrorResponse item)
        {
            if (!ModelState.IsValid) return View(item);
            await DocumentDbRepository<CrmErrorResponse>.UpdateItemAsync(item.Id, item);
            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = await DocumentDbRepository<CrmErrorResponse>.GetItemAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var item = await DocumentDbRepository<CrmErrorResponse>.GetItemAsync(id);
            if (item == null)
                return HttpNotFound();

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "Id")] string id)
        {
            await DocumentDbRepository<CrmErrorResponse>.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }


        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id)
        {
            var item = await DocumentDbRepository<CrmErrorResponse>.GetItemAsync(id);
            return View(item);
        }
    }
}