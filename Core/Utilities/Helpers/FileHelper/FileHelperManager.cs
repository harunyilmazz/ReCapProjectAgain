using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public IResult Delete(string filePath)
        {
            DeleteOldImageFile(filePath); //Aynı isimli dosya var mı diye kontrol yapar ve varsa siler.
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, string filePath, string root)
        {
            DeleteOldImageFile(filePath);
            return Upload(file, root);
        }

        public IResult Upload(IFormFile file, string root)
        {
            var fileExists = CheckFileExists(file); //Dosya varlığı method ile kontrol edilir.
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }
            var extension = Path.GetExtension(file.FileName); //Yükleyeceğimiz dosyanın uzantısını alır. Örn: .jpg
            var extensionValid = CheckFileExtensionValid(extension); //Dosyanın tip uygunluğu method ile kontrol eder.
            string guid = Guid.NewGuid().ToString(); //Dosyanın yeni random ismi(GUID) elde edilir.
            string filePath = guid + extension; //GUID ile dosya uzantısı birleştirilerek yeni dosya yolu oluşturulur.

            if (extensionValid.Message != null)
            {
                return new ErrorResult(extensionValid.Message);
            }

            CheckDirectoryExists(root); //Method ile dosyanın kaydedileceği dizin kontrolü yapılır, yoksa dizin oluşturulur.
            CreateImageFile(root + filePath,file); // Belirtilen yolda bir dosya oluşturur veya üzerine yazar ve bellek boşaltılır
            return new SuccessResult(filePath); //SQL'e kayıt için dosya adını döndürüyoruz.
        }

        //Kontrol methodları

        private static IResult CheckFileExists(IFormFile file) 
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Dosya yok");
        }

        private static IResult CheckFileExtensionValid(string extension) 
        {
            if (extension != ".jpeg" && extension != ".png" && extension != ".jpg")
            {
                return new ErrorResult("Hatalı dosya uzantısı");
            }
            return new SuccessResult();
        }

        private static void CheckDirectoryExists(string root) 
        {
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
        }

        private static void CreateImageFile(string directory,IFormFile file) 
        {
            using (FileStream fileStream = File.Create(directory))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
        }

        private static void DeleteOldImageFile(string filePath) 
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
