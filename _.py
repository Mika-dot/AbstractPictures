import os
import random
import string
from PIL import Image
from transformers import pipeline  # добавляем эту строку

def random_string(length):
    letters = string.ascii_lowercase
    return ''.join(random.choice(letters) for i in range(length))

def rename_images(directory):
    for filename in os.listdir(directory):
        if filename.endswith(".jpg") or filename.endswith(".png"):
            new_name = random_string(8) + os.path.splitext(filename)[1]
            os.rename(os.path.join(directory, filename), os.path.join(directory, new_name))

def describe_image(image_path):
    image_captioning = pipeline("image-to-text")
    image = Image.open(image_path)
    caption = image_captioning(image)[0]['generated_text']
    return caption

def process_image_and_save_description(image_path, output_dir='.'):
    image_name = os.path.splitext(os.path.basename(image_path))[0]
    description = describe_image(image_path)
    description_file = os.path.join(output_dir, f"{image_name}.txt")
    with open(description_file, 'w') as file:
        file.write(description)

word_to_add = "Asshole, Black Hair, Lingerie, Skinny, Tall"
word_to_addS = "Naughty and horny girl Dita V slips out of her sexy lingerie on the couch"

images_directory = r'C:\Users\Akim\Downloads\img\24'  # Замените на путь к вашей папке с изображениями
rename_images(images_directory)
print(f"Переименовал")

# Проводим обработку для каждого изображения
for subdir, _, files in os.walk(images_directory):
    for file in files:
        if file.endswith(".jpg"):
            image_file = os.path.join(subdir, file)
            process_image_and_save_description(image_file, subdir)

print(f"Аннотация")

# Получаем список файлов в папке с описаниями
description_files = [os.path.join(subdir, f) for subdir, _, files in os.walk(images_directory) for f in files if f.endswith('.txt')]

# Цикл для открытия файлов и добавления слов
for file in description_files:
    with open(file, 'a') as f:
        f.write(word_to_add + ', ' + word_to_addS + '\n')

print(f"Добавление")
