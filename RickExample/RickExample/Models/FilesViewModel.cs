﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RickExample.Models
{
    public class FilesViewModel
    {
        public MyDriveInfo DriveInformation { get; set; }
        public IEnumerable<MyFileInfo> MyFiles { get; set; }
        public IEnumerable<SelectListItem> MyFilesSelectList { get; set; }
    }

    public class MyDriveInfo
    {
        public long TotalFreeSpace { get; set; }
        public string VolumeLabel { get; set; }
    }

    public class MyFileInfo
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public DateTime CreationTime { get; set; }
        public string DirectoryName { get; set; }
        public string Extension { get; set; }
        public bool IsReadOnly { get; set; }
    }
}