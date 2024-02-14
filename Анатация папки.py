from transformers import pipeline
from PIL import Image
import os

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
def process_image_and_save_description(image_path):
    # Получаем имя файла из полного пути
    image_name = os.path.basename(image_path).split('.')[0]
    
    # Получаем описание картинки
    annotated_description = describe_image(image_path)

    # Создаем имя файла для сохраниения описания
    description_file = f"{image_name}.txt"

    # Сохраняем описание в файл
    with open(description_file, 'w', encoding='utf-8') as file:
        file.write(annotated_description)

    print(f"Description saved to {description_file}")

# Получаем список файлов в текущей директории
image_files = [f for f in os.listdir() if os.path.isfile(f) and f.lower().endswith(('.png', '.jpg', '.jpeg'))]

# Проходим по всем файлам и генерируем описание
for image_file in image_files:
    process_image_and_save_description(image_file)
