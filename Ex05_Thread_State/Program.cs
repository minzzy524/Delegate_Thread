using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Ex05_Thread_state
{
    class Program
    {
        static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000); // 스레드 잠깐 1초 재움 // 잠깐 쉴 때 A 누르면 주 스레드 돌려서 삑 소리 낼 수 있다

            }
            Console.WriteLine("스레드 종료");
        }
        static void Main(string[] args)
        {
            Thread T = new Thread(new ThreadStart(ThreadProc));
            T.Start();

            for (; ; ) // 무한 for문 , 주 스레드
            {
                ConsoleKeyInfo cki; // 콘솔창에서 자판 값 받는 것
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.A)
                {
                    Console.Beep(); // 보드에서 소리 나게 해라
                }
                if (cki.Key == ConsoleKey.B)
                {
                    break;
                }

            }
            Console.WriteLine("주 스레드 종료");
        }
    }
}