from transformers import pipeline
from PIL import Image

# Функция для создания описания картинки
def describe_image(image_path):
    # Инициализируем пайплайн для генерации описания изображения
    image_captioning = pipeline("image-to-text")

    # Открываем изображение
    image = Image.open(image_path)
    
    # Генерируем описание
    annotated_description = image_captioning(image)[0]['generated_text']

    return annotated_description

# Основная функция для обработки изображения и сохранения описания в файл
def process_image_and_save_description():
    # Получаем путь к файлу из пользовательского ввода
    image_path = input("Введите путь к файлу картинки: ")

    # Получаем имя файла из полного пути
    image_name = image_path.split('/')[-1].split('.')[0]
    
    # Получаем описание картинки
    annotated_description = describe_image(image_path)

    # Создаем имя файла для сохраниения описания
    description_file = f"{image_name}.txt"

    # Сохраняем описание в файл
    with open(description_file, 'w') as file:
        file.write(annotated_description)

    print(f"Description saved to {description_file}")

# Пример вызова функции
process_image_and_save_description()
