import os
from PIL import Image
from tkinter import Tk
from tkinter.filedialog import askdirectory
import sys

def resize_images(directory, new_width, new_height):
    image_files = [f for f in os.listdir(directory) if f.endswith(('jpg', 'jpeg', 'png'))]
    total_files = len(image_files)
    
    if total_files == 0:
        print("No image files found in the directory.")
        return
    
    for idx, file_name in enumerate(image_files):
        try:
            file_path = os.path.join(directory, file_name)
            with Image.open(file_path) as img:
                img = img.resize((new_width, new_height), Image.LANCZOS)
                img.save(file_path)
            
            percent_complete = ((idx + 1) / total_files) * 100
            sys.stdout.write(f"\rProcessing: {percent_complete:.2f}% complete")
            sys.stdout.flush()
        except Exception as e:
            print(f"Error processing {file_name}: {e}")
    
    print("\nProcessing complete.")

def get_directory():
    Tk().withdraw()  # Close the root window
    directory = askdirectory()
    return directory

def main():
    print("Select the directory containing the images:")
    directory = get_directory()
    if not directory:
        print("No directory selected. Exiting.")
        return

    new_width = int(input("Enter new width: "))
    new_height = int(input("Enter new height: "))
    
    resize_images(directory, new_width, new_height)

if __name__ == "__main__":
    main()
