namespace FutureRealty.PL.Helpers
{
    public class FileSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string filePath = Path.Combine(folderPath, fileName);

            var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);

            return fileName;
        }

        public static void DeleteFile(string fileName, string folderName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

    }
}
