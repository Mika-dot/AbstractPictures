import cv2
import os
import tkinter as tk
from tkinter import filedialog

def split_video_into_frames(video_path):
    video_name = os.path.splitext(os.path.basename(video_path))[0]
    output_folder = os.path.join(os.path.dirname(video_path), video_name)
    os.makedirs(output_folder, exist_ok=True)

    cap = cv2.VideoCapture(video_path)
    frame_count = 0
    total_frames = int(cap.get(cv2.CAP_PROP_FRAME_COUNT))

    while True:
        ret, frame = cap.read()
        if not ret:
            break
        frame_count += 1
        frame_path = os.path.join(output_folder, f"{frame_count}.jpg")
        cv2.imwrite(frame_path, frame)

        percent_processed = frame_count / total_frames * 100
        print(f"Processed: {percent_processed:.2f}%")

    cap.release()

root = tk.Tk()
root.withdraw()  # Скрыть основное окно

video_path = filedialog.askopenfilename(title="Выберите файл видео")

if video_path:
    split_video_into_frames(video_path)