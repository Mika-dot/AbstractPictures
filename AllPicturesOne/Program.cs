string sourceDirectory = @"C:\Users\Akim\Downloads\img"; // Месть папки с папками
string destinationDirectory = @"C:\Users\Akim\Downloads\imgAll"; // Куда сохраняеться

CopyAndRenameImages(sourceDirectory, destinationDirectory);

Console.WriteLine("Изображения успешно скопированы и переименованы.");


// ----------------------------------------------------------------------------------------------- //

// Метод для копирования и переименования изображений
static void CopyAndRenameImages(string sourceDirectory, string destinationDirectory)
{
    int counter = 1;
    foreach (string file in Directory.EnumerateFiles(sourceDirectory, "*.*", SearchOption.AllDirectories))
    {
        if (IsImageFile(file))
        {
            string newFilePath = Path.Combine(destinationDirectory, $"image{counter}.jpg");
            File.Copy(file, newFilePath);
            counter++;
        }
    }
}

// Метод для проверки, является ли файл изображением
static bool IsImageFile(string filePath)
{
    string extension = Path.GetExtension(filePath);
    return extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
           extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
           extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
           extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
           extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
}
