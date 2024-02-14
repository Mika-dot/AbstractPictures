using Microsoft.VisualBasic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForms
{
    public partial class Form1 : Form
    {
        private string[] imagePaths;
        private int currentIndex;
        private string adress;

        public Form1()
        {
            InitializeComponent();

            string folderPath = Interaction.InputBox("Введите путь к папке:", "Путь к папке", "C:\\");
            if (!string.IsNullOrEmpty(folderPath))
            {
                adress = folderPath; // MessageBox.Show("Выбранный путь: " + folderPath);
            }

            imagePaths = Directory.GetFiles(adress); // Замените на актуальный путь
            currentIndex = 0;
            ShowImage();
        }

        private void ShowImage()
        {
            if (currentIndex < imagePaths.Length)
            {
                Bitmap image = new Bitmap(imagePaths[currentIndex]);
                pictureBox1.Image = image;
                textBox1.Text = ""; // очистим поле с предыдущим описанием
                button1.Text = currentIndex + " из " + imagePaths.Length;
            }
            else
            {
                MessageBox.Show("Все изображения просмотрены.");
            }
        }

        string text = "";

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (currentIndex < imagePaths.Length)
            {
                text = textBox1.Text;
                button2.Text = text;
                


                string imageName = Path.GetFileNameWithoutExtension(imagePaths[currentIndex]);
                string description = textBox1.Text;
                string descriptionFilePath = Path.Combine(adress, imageName + ".txt"); // Замените на актуальный путь

                File.WriteAllText(descriptionFilePath, description);
                currentIndex++;
                ShowImage();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = text;
        }
    }
}
