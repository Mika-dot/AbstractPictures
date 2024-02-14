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
    string imageUrl = $"https://www.пфффф.info/{i}.webp";
    string filePath = $"{folderPath}\\photo_{i}.jpg";

    client.DownloadFile(imageUrl, filePath);
}

Console.WriteLine("Фотографии успешно сохранены.");
