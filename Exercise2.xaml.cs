using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Diagnostics;

namespace Threads
{
    /// <summary>
    /// Interaction logic for Exercise2.xaml
    /// </summary>
    public partial class Exercise2 : Window
    {
        Thread IterationThread;
        Thread RecursionThread;
                    
        public Exercise2()
        {
            InitializeComponent();

            IterationFactorial();
            RecursionFactorial();
        }

        private void runIteration_button_Click(object sender, RoutedEventArgs e)
        {
            IterationFactorial();
        }

        private void runRecursion_button_Click(object sender, RoutedEventArgs e)
        {
            RecursionFactorial();
        }

        private void runIterationAndRecursion_button_Click(object sender, RoutedEventArgs e)
        {
            IterationFactorial();
            RecursionFactorial();
        }

        private void abortIteration_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IterationThread.IsAlive)
                {
                    IterationThread.Abort();
                }
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Thread doesn't exist! Orginal Error: " + ex.Message);
            }
        }

        private void abportRecursion_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RecursionThread.IsAlive)
                {
                    RecursionThread.Abort();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Thread doesn't exist! Orginal Error: " + ex.Message);
            }
        }


        private void IterationFactorial()
        {
            Factorial factorial = new Factorial();

            int factorialNumberIteration;
            if (int.TryParse(nIteration_textBox.Text, out factorialNumberIteration)) { }
            else
            {
                System.Windows.Forms.MessageBox.Show("Value is not a number!", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultIteration_textBlock.Text = "ABORT";
                timeIteration_textBlock.Text = "ABORT";
                return;
            }


            IterationThread = new Thread(factorial.iterationDelegate);
            IterationThread.Name = "IterationFactorial";
            IterationThread.Start(factorialNumberIteration);

            IterationThread.Join();
            resultIteration_textBlock.Text = factorialNumberIteration + "!= " + factorial.resultIteration;
            timeIteration_textBlock.Text = factorial.calculationTimeIteration;
        }

        private void RecursionFactorial()
        {
            Factorial factorial = new Factorial();

            int factorialNumberRecursion;
            if (int.TryParse(nRecursion_textBox.Text, out factorialNumberRecursion)) { }
            else
            {
                System.Windows.Forms.MessageBox.Show("Value is not a number!", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultRecursion_textBlock.Text = "ABORT";
                timeRecursion_textBlock.Text = "ABORT";
                return;
            }

            RecursionThread = new Thread(factorial.recursionDelegate);
            RecursionThread.Name = "RecursionFactorial";
            RecursionThread.Start(factorialNumberRecursion);

            RecursionThread.Join();
            resultRecursion_textBlock.Text = factorialNumberRecursion + "!= " + factorial.resultRecursion;
            timeRecursion_textBlock.Text = factorial.calculationTimeRecursion;
        }
    }


    public class Factorial
    {

        public string resultIteration { get; set; }
        public string calculationTimeIteration { get; set; }

        public string resultRecursion { get; set; }
        public string calculationTimeRecursion { get; set; }

        public Factorial() { }

        public void iterationDelegate(object number)
        {
            int n = (int)number;
            var executionTime = Stopwatch.StartNew();
                resultIteration = iteration(n).ToString();
            executionTime.Stop();
            calculationTimeIteration = executionTime.Elapsed.ToString();
        }
        private double iteration(int n)
        {
            if(n == 0)
            {
                return 1;
            }
            else
            {
                double result = 1;
                while(n > 0)
                {
                    result *= n;
                    n--;
                }
                Console.WriteLine(result);
                return result;
            }
        }


        public void recursionDelegate(object number)
        {
            int n = (int)number;
            var executionTime = Stopwatch.StartNew();
                resultRecursion = recursion(n).ToString();
            executionTime.Stop();
            calculationTimeRecursion = executionTime.Elapsed.ToString();

        }
        private double recursion(int n)
        {
            if ((int)n == 0)
            {
                return 1;
            }
            else
            {
                return n * recursion(n - 1);
            }
        }

    }
}
