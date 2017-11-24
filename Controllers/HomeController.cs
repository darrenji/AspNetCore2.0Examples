using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.IO;
using Examples.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examples.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileProvider fileProvider;

        public HomeController(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }
        public IActionResult Index()
        {
            return View();
        }

        //使用IFormFile接受前端传来的文件
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            //检查文件是否存在，是否有内容
            if(file==null||file.Length==0)
            {
                return Content("file not selected");
            }

            //文件的保存路径
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.GetFilename());

            //把流搭建起来
            using (var stream = new FileStream(path, FileMode.Create))
            {
                //把文件保存到流里
                await file.CopyToAsync(stream);
            }
            return RedirectToAction("Files");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files) 
        {
            if(files==null || files.Count == 0)
            {
                return Content("files not selected");
            }

            foreach(var file in files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.GetFilename());
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return RedirectToAction("Files");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileViaModel(FileInputModel model)
        {
            if(model==null || model.FileToUpload == null || model.FileToUpload.Length == 0)
            {
                return Content("file not selected");
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", model.FileToUpload.GetFilename());

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.FileToUpload.CopyToAsync(stream);
            }
            return RedirectToAction("Files");
        }

        public IActionResult Files()
        {
            var model = new FilesViewModel();
            foreach(var item in this.fileProvider.GetDirectoryContents(""))
            {
                model.Files.Add(new FileDetails { Name=item.Name, Path=item.PhysicalPath});
            }
            return View(model);
        }

        public async Task<IActionResult> Download(string filename)
        {
            if(filename==null)
            {
                return Content("filename not present");

            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

    }
}
