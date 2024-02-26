import cv2
import os

# Функция для обработки событий мыши в OpenCV
def on_mouse(event, x, y, flags, param):
    global x_start, y_start, x_end, y_end, cropping
    if event == cv2.EVENT_LBUTTONDOWN:
        x_start, y_start, x_end, y_end = x, y, x, y
        cropping = True
    elif event == cv2.EVENT_MOUSEMOVE:
        if cropping:
            x_end, y_end = x, y
            image_with_rectangle = image.copy()
            cv2.rectangle(image_with_rectangle, (x_start, y_start), (x, y), (0, 255, 0), 2)
            cv2.imshow("Image", image_with_rectangle)
    elif event == cv2.EVENT_LBUTTONUP:
        x_end, y_end = x, y
        cropping = False
        refPoint = [(x_start, y_start), (x_end, y_end)]
        if len(refPoint) == 2:
            roi = clone[refPoint[0][1]:refPoint[1][1], refPoint[0][0]:refPoint[1][0]]
            cv2.imshow("Cropped", roi)
            cv2.waitKey(0)
            # Сохраняем выделенную область во вторую папку
            cv2.imwrite(save_path + filename, roi)

# Пути к папкам
input_folder = r'C:\Users\Akim\Downloads\IMGNEW'  # Путь к папке с изображениями
output_folder = r'C:\Users\Akim\Downloads\IMGNEW_fase'  # Путь, куда сохранять выделенные области

# Загрузка списка изображений
image_files = [f for f in os.listdir(input_folder) if os.path.isfile(os.path.join(input_folder, f))]

cropping = False
x_start, y_start, x_end, y_end = 0, 0, 0, 0

# Создаем папку для вырезанных изображений, если она не существует
if not os.path.exists(output_folder):
    os.makedirs(output_folder)
    
# Основной цикл для открытия и обработки каждого изображения
for filename in image_files:
    img_path = os.path.join(input_folder, filename)
    save_path = os.path.join(output_folder, filename)
    
    # Проверяем наличие файла перед загрузкой
    if os.path.isfile(img_path):
        image = cv2.imread(img_path)
    else:
        print(f"File {filename} not found")
        continue

    if image is None:
        print(f"Failed to load image: {filename}")
        continue

    clone = image.copy()
    cv2.namedWindow("Image")
    cv2.setMouseCallback("Image", on_mouse)

    # Цикл показа изображения и обработки выделения области
    while True:
        cv2.imshow("Image", image)
        key = cv2.waitKey(1) & 0xFF
        # Перерисовываем прямоугольник выбора
        if cropping:
            rect_cpy = image.copy()
            cv2.rectangle(rect_cpy, (x_start, y_start), (x_end, y_end), (0, 255, 0), 2)
            cv2.imshow("Image", rect_cpy)
        # Если 'r' нажата, возобновляем цикл (перезагрузить изображение)
        elif key == ord('r'):
            image = clone.copy()
        # Если 'c' нажата, выходим из цикла (перейти к следующему изображению)
        elif key == ord('c'):
            break

    # Закрываем все открытые окна
    cv2.destroyAllWindows()
