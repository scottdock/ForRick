using RickExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RickExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // option #1 - retrieve list of filenames (as full paths) 
            //var vm = new FilesViewModel();
            //var files = System.IO.Directory.GetFiles(@"C:\code\me\RickExample\RickExample\fonts");
            //vm.FileNames = files;
            //return View(vm);


            // option #2 - get more information 
            var vm = new FilesViewModel();

            // get info from drive & append to View Model
            System.IO.DriveInfo drive = new System.IO.DriveInfo(@"C:\");
            var driveInfo = new RickExample.Models.MyDriveInfo();
            driveInfo.TotalFreeSpace = driveInfo.TotalFreeSpace;
            driveInfo.VolumeLabel = driveInfo.VolumeLabel;
            vm.DriveInformation = driveInfo;

            // get file information 
            var files = System.IO.Directory.GetFiles(@"C:\code\ForRick\RickExample\RickExample\fonts");
            var filesInfo = new List<MyFileInfo>();
            var ctr = 0;
            foreach (var file in files)
            {
                var currentFile = new System.IO.FileInfo(file);
                var outputFileInfo = new RickExample.Models.MyFileInfo();
                ctr++;
                outputFileInfo.FileId = ctr;
                outputFileInfo.FileName = currentFile.Name;
                outputFileInfo.CreationTime = currentFile.CreationTime;
                outputFileInfo.DirectoryName = currentFile.DirectoryName;
                outputFileInfo.Extension = currentFile.Extension;
                outputFileInfo.IsReadOnly = currentFile.IsReadOnly; 
                filesInfo.Add(outputFileInfo);
            }
            vm.MyFiles = filesInfo;
            vm.MyFilesSelectList = BuildSelectListItemFromModelList(vm.MyFiles);

            // return View with data 
            return View(vm);
        }

        private List<SelectListItem> BuildSelectListItemFromModelList(IEnumerable<MyFileInfo> myFiles)
        {
            var items = new List<SelectListItem>();
            var ctr = 0;
            foreach (var file in myFiles)
            {
                ctr++;
                items.Add(new SelectListItem { Text = file.FileName, Value = ctr.ToString() });
            }
            return items;

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}