using System.Net;

//[DllImport("user32.dll")]
//static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, IntPtr dwExtraInfo);
//[DllImport("user32.dll")]
//static extern bool SetCursorPos(int X, int Y);


//const int MOUSEEVENTF_LEFTDOWN = 0x02;
//const int MOUSEEVENTF_LEFTUP = 0x04;

//while (true)
//{
//    MoveMouseTo(260, 780);
//    mouse_event(MOUSEEVENTF_LEFTDOWN, 260, 780, 0, IntPtr.Zero);
//    mouse_event(MOUSEEVENTF_LEFTUP, 260, 780, 0, IntPtr.Zero);
//    System.Threading.Thread.Sleep(5000);
//}

//static void MoveMouseTo(int x, int y)
//{
//    // Получаем размеры экрана
//    int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
//    int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

//    // Рассчитываем новые координаты относительно размеров экрана
//    int newX = (int)x;
//    int newY = (int)y;

//    // Перемещаем мышку по заданным координатам относительно всего экрана
//    SetCursorPos(newX, newY);
//}

//string sourceDirectory = @"C:\Users\Akim\Downloads\imgAll512";
//string destinationDirectory = @"C:\Users\Akim\Downloads\imgAll512TXTIMG";

//// Поиск всех изображений в исходной папке
//string[] imageFiles = Directory.GetFiles(sourceDirectory, "*.jpg");
//imageFiles = imageFiles.Concat(Directory.GetFiles(sourceDirectory, "*.png")).ToArray();
//imageFiles = imageFiles.Concat(Directory.GetFiles(sourceDirectory, "*.gif")).ToArray();
//imageFiles = imageFiles.Concat(Directory.GetFiles(sourceDirectory, "*.bmp")).ToArray();

//foreach (string imageFile in imageFiles)
//{
//    // Получение пути к файлу изображения
//    string fileName = Path.GetFileName(imageFile);

//    // Проверка наличия текстового файла соответствующего изображению
//    string txtFile = Path.ChangeExtension(imageFile, ".txt");
//    if (File.Exists(txtFile))
//    {
//        // Перемещение изображения и текстового файла в другую папку
//        string destinationImageFile = Path.Combine(destinationDirectory, fileName);
//        string destinationTxtFile = Path.ChangeExtension(destinationImageFile, ".txt");
//        File.Move(imageFile, destinationImageFile);
//        File.Move(txtFile, destinationTxtFile);

//        Console.WriteLine($"Файлы {fileName} и {Path.GetFileName(destinationTxtFile)} успешно перемещены.");
//    }
//}

//;

//string folderPath = @"C:\Users\Akim\Downloads\imgAll512";
//string[] txtFiles = Directory.GetFiles(folderPath, "*.txt");

//var Translate = new AccessURL();
//string[] separators = new string[] { "[[[\"", "\",\"" };

//foreach (string file in txtFiles)
//{
//    string originalText = File.ReadAllText(file);
//    string convertedText = await ConvertAsync(originalText);
//    File.WriteAllText(file, convertedText);
//    Console.WriteLine($"File {file} has been converted and saved.");
//}
//;

//async Task<string> ConvertAsync(string text)
//{
//    return (await Translate.GetTextAsync(text)).Split(separators, StringSplitOptions.None)[1]; ;
//}



string path = "C:\\Users\\Akim\\Downloads\\Новая папка (2)\\4";
string[] files = Directory.GetFiles(path, "*.jpg"); // Можно изменить расширение файла

foreach (string file in files)
{
    Console.WriteLine($"Отображение изображения: {file}");

    // Отображение изображения на экране
    System.Diagnostics.Process.Start(file);

    // Запрос описания от пользователя
    Console.Write("Введите описание изображения: ");
    string description = Console.ReadLine();

    // Сохранение описания в файл с тем же именем
    string descriptionFilePath = Path.Combine(path, Path.GetFileNameWithoutExtension(file) + ".txt");
    File.WriteAllText(descriptionFilePath, description);

    // Ожидание ввода пользователя перед отображением следующего изображения
    Console.WriteLine("Нажмите Enter для показа следующего изображения");
    Console.ReadLine();
}

Console.WriteLine("Все изображения обработаны.");


string sourceDirectory = @"C:\Users\Akim\Downloads\img";
string destinationDirectory = @"C:\Users\Akim\Downloads\imgAll";

CopyAndRenameImages(sourceDirectory, destinationDirectory);

Console.WriteLine("Изображения успешно скопированы и переименованы.");



string folderPath = @"C:\Users\Akim\Downloads\img\15"; // Замените путь на нужный путь к папке
if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
    Console.WriteLine("Папка успешно создана.");
}
WebClient client = new WebClient();

for (int i = 1; i <= 40; i++)
{
    string imageUrl = $"https://www.girlstop.info/cat/posts/659aacc79101c9.37620893/{i}.webp";
    string filePath = $"{folderPath}\\photo_{i}.jpg";

    client.DownloadFile(imageUrl, filePath);
}

Console.WriteLine("Фотографии успешно сохранены.");




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
