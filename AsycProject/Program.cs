using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsycProject
{
    class Program
    {
        static void Main(string[] args)
        {

            DownloadFileFromServer();

            // alternative method to call the thread
            // Technique no 2
            //Task.Run(() =>
            //{
            //    // Main Thread
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine($"Main Thread is .........{i}");
            //        Console.ForegroundColor = ConsoleColor.DarkRed;
            //        Thread.Sleep(500);
            //    }
            //});

            // worker Threads
            //WorkerThread1();
            //WorkerThread2();
            //WorkerThread3();

            // Technique no 1
            // very easy and convenient method to call the thread 
            //Thread thread1 = new Thread(WorkerThread1);
            //thread1.Start();
            //Thread thread2 = new Thread(WorkerThread2);
            //thread2.Start();
            //Thread thread3 = new Thread(WorkerThread3);
            //thread3.Start();

            Console.ReadLine();
        }

        static void WorkerThread1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Worker Thread 1 is .........{i}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Thread.Sleep(500);
            }
        }
        static void WorkerThread2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Worker Thread  2 is .........{i}");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Thread.Sleep(500);
            }
        }
        static void WorkerThread3()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Worker Thread  3 is .........{i}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Thread.Sleep(500);
            }
        }

        static async void DownloadFileFromServer()
        {
            // how client send client request to server for some data
           
            HttpClient client = new HttpClient();
            Task<string> getTaskString =  client.GetStringAsync("https://www.google.com/");
            var data = await getTaskString;
            Thread thread1 = new Thread(WorkerThread1);
            thread1.Start();
            Thread thread2 = new Thread(WorkerThread2);
            thread2.Start();
            Thread thread3 = new Thread(WorkerThread3);
            thread3.Start();


            Console.WriteLine(data);
        }
    }
}
