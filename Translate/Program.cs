using Translate;



string folderPath = "C:\\Users\\Akim\\Downloads\\Новая папка (2)\\Face"; // Укажите путь к исходной папке
string[] txtFiles = Directory.GetFiles(folderPath, "*.txt");

foreach (var filePath in txtFiles)
{
    string fileContent = await File.ReadAllTextAsync(filePath);
    string translatedContent = await TranslateContentAsync(fileContent); // Предположим, что у вас есть метод для перевода текста

    await File.WriteAllTextAsync(filePath, translatedContent);
}
Console.WriteLine("стоп");

static async Task<string> TranslateContentAsync(string content)
{
    var Translate = new AccessURL();
    // Здесь вызывается метод для перевода текста
    // Предположим, что у вас есть метод Translate.GetTextAsync и он возвращает переведенный текст
    string translatedText = await Translate.GetTextAsync(content);
    string[] translatedTextArr = translatedText.Split(new string[] { "[[[\"", "\",\"" }, StringSplitOptions.None);

    return translatedTextArr[1];
}