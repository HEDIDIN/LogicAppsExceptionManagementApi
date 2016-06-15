using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using LogManagement.Models;

namespace LogManagement.Controllers
{
    public class LogsController : Controller
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await DocumentDbRepository<CrmRequest>.GetItemsAsync(response => response.NotDeleted);
            return View(items);
        }


        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id)
        {
            var item = await DocumentDbRepository<CrmRequest>.GetItemAsync(id);
            return View(item);
        }

        /// <summary>
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


        /// <summary>
        ///     convert JSON string to List
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private IList<SourceList> GetList(string source)
        {
            // Call the deserializer
            var validList = List.DeserializeToList<SourceList>(source);

            return validList;
        }
    }
}