using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using MWeb_test.Models;
using System.IO;




namespace MWeb_test.Controllers
{
    public class MarkersController : Controller
    {
        private readonly Mweb_DataTableFirstContext _context;
        private readonly HostingEnvironment _hostingEnvironment;

        //?
        //public Markers markers { get; set; }

        public MarkersController(Mweb_DataTableFirstContext context, HostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }



        // GET: Markers
        public async Task<IActionResult> Index()
        {
            var mweb_DataTableFirstContext = _context.Markers.Include(m => m.User);
            return View(await mweb_DataTableFirstContext.ToListAsync());
        }

        // GET: Markers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markers = await _context.Markers
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MarkerId == id);
            if (markers == null)
            {
                return NotFound();
            }

            return View(markers);
        }

        // GET: Markers/Create
        public IActionResult Create()
        {
            //_context.Add(Markers);
            //_context.SaveChanges();

            ViewData["UserId"] = new SelectList(_context.Userss, "UserId", "UserEmail");

            ////Save Makrer Logic

            ////Get bike id we have saved in Db
            //var MarkerId = markers.MarkerId;

            ////Get wwwrootpath to save the file on server
            //var wwwrootPath = _hostingEnvironment.WebRootPath;

            ////Get the uploaded files
            //var files = HttpContext.Request.Form.Files;

            ////Get the reference of DBSet for the bike we just have saved in Db
            //var SavedMarker = _context.Markers.Find(MarkerId);


            ////Upload the files on server and save the image path of user have uploaded any files
            //if (files.Count != 0)
            //{
            //    var ImagePath = @"images\marker\";
            //    var Extension = Path.GetExtension(files[0].FileName);
            //    var RelativeImagePath = ImagePath + MarkerId + Extension;
            //    var AbsImagePath = Path.Combine(wwwrootPath, RelativeImagePath);

            //    //Upload the file on server
            //    using(var fileStream = new FileStream(AbsImagePath, FileMode.Create))
            //    {
            //        files[0].CopyTo(fileStream);
            //    }

            //    SavedMarker.PhotoPath = RelativeImagePath;
            //    _context.SaveChanges();
            //}
            return View();
        }

        // POST: Markers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [RequestSizeLimit(10000000)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarkerId,UserId,MarkerLat,MarkerLng,Photo,PhotoPath")] Markers markers)
        {
            var files = HttpContext.Request.Form.Files;
            string path = "wwwroot/images/marker/";
            string extension = "";

            if (files.Count == 0)
            {
                return RedirectToAction("Create");
            }

            for (int i = files[0].FileName.Length - 1; i > 0; i--)
            {
                if (files[0].FileName[i] == '.')
                {
                    break;
                }
                extension = files[0].FileName[i].ToString() + extension;
            }

            extension = extension.ToLower();
            if (extension == "jpg" || extension == "jpeg" || extension == "png")
            {
                markers.PhotoPath = Guid.NewGuid().ToString() + "." + extension;
                path += markers.PhotoPath;
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                _context.Add(markers);
            }


            if (ModelState.IsValid)
            {
                _context.Add(markers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Userss, "UserId", "UserEmail", markers.UserId);
            return View(markers);
        }
        private async Task<(bool, string)> UploadToBlob(string filename, Stream stream = null, string extension = "")
        {
            CloudStorageAccount storageAccount = null;
            CloudBlobContainer cloudBlobContainer = null;
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=mwebimagestor;AccountKey=yqbcAuQ3zimHLAicsV96j34AXrvdA8naHhwy2751IKwU+TgrU9c5Zc1elG2xAd5z8TKBaBQBdhqlGecvQsya6A==;EndpointSuffix=core.windows.net";

            // Check whether the connection string can be parsed.
            if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
            {
                try
                {
                    // Create the CloudBlobClient that represents the Blob storage endpoint
                    CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

                    // Add to images container 
                    cloudBlobContainer = cloudBlobClient.GetContainerReference("images");

                    // Set the permissions so the blobs are public. 
                    BlobContainerPermissions permissions = new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    };
                    await cloudBlobContainer.SetPermissionsAsync(permissions);

                    // Get a reference to the blob address, then upload the file to the blob.
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(filename);


                    if (stream != null)
                    {
                        // Pass in memory stream directly

                        cloudBlockBlob.Properties.ContentType = "image/" + extension;

                        await cloudBlockBlob.UploadFromStreamAsync(stream);
                    }
                    else
                    {
                        return (false, null);
                    }

                    return (true, cloudBlockBlob.SnapshotQualifiedStorageUri.PrimaryUri.ToString());
                }
                catch (StorageException ex)
                {
                    return (false, null);
                }
            }
            else
            {
                return (false, null);
            }

        }
        // GET: Markers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markers = await _context.Markers.FindAsync(id);
            //var markers = await _context.Markers;
            if (markers == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Userss, "UserId", "UserEmail", markers.UserId);
            return View(markers);
        }

        // POST: Markers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarkerId,UserId,MarkerLat,MarkerLng,Photo,PhotoPath")] Markers markers)
        {
            if (id != markers.MarkerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(markers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkersExists(markers.MarkerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Userss, "UserId", "UserEmail", markers.UserId);
            return View(markers);
        }

        // GET: Markers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markers = await _context.Markers
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MarkerId == id);
            if (markers == null)
            {
                return NotFound();
            }

            return View(markers);
        }

        // POST: Markers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var markers = await _context.Markers.FindAsync(id);
            _context.Markers.Remove(markers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkersExists(int id)
        {
            return _context.Markers.Any(e => e.MarkerId == id);
        }
    }
}
