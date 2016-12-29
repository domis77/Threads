using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.IO;


namespace Threads
{
    /// <summary>
    /// Interaction logic for Exercise1.xaml
    /// </summary>
    public partial class Exercise1 : Window
    {
        public Exercise1()
        {
            InitializeComponent();
        }
        
        private void selectPath_button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();

            ZippBomb zippBomb = new ZippBomb(10, folderBrowserDialog.SelectedPath);
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }


    public class ZippBomb
    {
        private Random rand = new Random();
        private string filePath;

        public ZippBomb(int threadsNumber, string filePath)
        {
            Thread[] threads = new Thread[threadsNumber];
            this.filePath = filePath;

            makeTheBomb(threads);
        }

        private void makeTheBomb(Thread[] threads)
        {
            BinaryFile binaryFile = new BinaryFile(filePath);

            for (var i=0; i< threads.Length; i++)
            {
                threads[i] = new Thread(binaryFile.createFile);
                threads[i].Start(i + 1);
            }
            System.Windows.Forms.MessageBox.Show("Done!", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        
    }


    class BinaryFile
    {
        private string filePath;
        Random rand;

        public BinaryFile(string filePath)
        {
            rand = new Random();
            this.filePath = filePath;
        }

        public void createFile(object fileNumber)
        {
            Byte[] bytes = new Byte[1048576];
            rand.NextBytes(bytes);

            try
            {
                string fileName = filePath + fileNumber.ToString() + ".bin";

                using (FileStream fileStream = File.Create(fileName))
                {
                    for (var i = 0; i < bytes.Length; i++)
                    {
                        fileStream.WriteByte(bytes[i]);
                    }
                }
            }
            catch (IOException ioexp)
            {
                System.Windows.MessageBox.Show("Error: " + ioexp.Message);
            }
            
        }
    }





}
