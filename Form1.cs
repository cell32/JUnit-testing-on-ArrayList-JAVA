using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FibonacciAsynchronous
{
    public partial class AsynchronousTestForm : Form
    {
        public AsynchronousTestForm()
        {
            InitializeComponent();
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            int userInput = int.Parse(inputTextBox1.Text); //takes userInput
            andFibonacci2Label.Text = ($"And fibonacci (x+1): ({userInput + 1})"); //modifying the lable tag
            andFibonacci3Label.Text = ($"And fibonacci (x+2): ({userInput + 2})"); //modifying the label tag

            outputTextBox.Text = "Starting tasks to calculate fibonaccis: " +
                "(" + inputTextBox1.Text + ") " +
                ", fibonacci (" + (userInput + 1) + ") and fibonacci (" + (userInput + 2) + ")\r\n";
                

                  //need to create method  StartFibonacci, for Task.
            Task<TimeData> task1 = Task.Run(() => StartFibonacci(userInput));
            Task<TimeData> task2 = Task.Run(() => StartFibonacci(userInput + 1));
            Task<TimeData> task3 = Task.Run(() => StartFibonacci(userInput + 2));

            await Task.WhenAll(task1, task2, task3); //, task3);

            //determine time when 1st thread started
            //DateTime startTime =
            //    (((task1.Result.StartTime  < task2.Result.StartTime && (task2.Result.StartTime < task3.Result.StartTime)))) ?
            //    task1.Result.EndTime : task3.Result.EndTime; // : task3.Result.EndTime;

            DateTime startTime =
                ((task1.Result.StartTime < task2.Result.StartTime) && (task2.Result.StartTime < task3.Result.StartTime)) ?
                   task1.Result.EndTime : task3.Result.EndTime; // : task3.Result.EndTime;

            DateTime endTime =
                ((task1.Result.EndTime > task2.Result.EndTime) &&  (task2.Result.StartTime > task3.Result.EndTime)) ?
                task1.Result.EndTime : task3.Result.EndTime;

            //display total minutes for the calculations
            double totalMinutes1 = (task3.Result.EndTime - task2.Result.StartTime).TotalMinutes;
            double totalMinutes2 = (task3.Result.EndTime - task1.Result.StartTime).TotalMinutes;
            outputTextBox.AppendText(
                $"Total calculations time is:  {totalMinutes2 + totalMinutes1:F6} minutes\r\n");
        }

        //Starts a call to fibonacci and captures start and end times
        TimeData StartFibonacci(int n)
        {
            //Create a TiemData object to store start and end times.
            var result = new TimeData();

            AppendText($"Calculating Fibonacci: ({n})");
            result.StartTime = DateTime.Now;
            long fibonacciValue = Fibonacci(n); //calling the fibonacci method on the n fibonacci # and storing result on fibnacciValue
            result.EndTime = DateTime.Now;
            
            AppendText($"Fibonacci: ({n}) = " + fibonacciValue );
            double minutes =
                (result.EndTime - result.StartTime).TotalMinutes;
            AppendText($"Calculation time = {minutes:F6} minutes\r\n");

            return result;
        }

        //recurive calculation of fibonacci numbers
        public long Fibonacci(long n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        public void AppendText(String text)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => AppendText(text)));
            }
            else
            {
                outputTextBox.AppendText(text + "\r\n");
            }

        }

    }

    internal class TimeData
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
