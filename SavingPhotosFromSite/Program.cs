using System.Net;

string folderPath = @"C:\Users\Akim\Downloads\img\15";
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