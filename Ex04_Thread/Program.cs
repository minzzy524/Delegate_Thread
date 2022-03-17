using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; // 추가하기

namespace Ex04_Thread

{

    // 하나의 프로세스에 한 개의 스레드를 동작(지금까지)
    // 한 개의 스레드 (Main() 함수 >> stack 메모리 사용

    // 하나의 프로세스 여러 개의 일꾼을 만들어 사용하겠다
    // 일꾼(stack, Thread) 사용

    // 문제점 : 공유자원
    // 1. System.Threading.ThreadStart 델리게이트(동작할 함수)
    // 2. Thread 객체를 생성하고 델리게이트를 통해서 함수를 등록 
    class Program
    {

        public static void sPrint()
        {
            Console.WriteLine("static 함수");
        }

        public void Print()
        {
            Console.WriteLine("일반 함수");
        }
        static void Main(string[] args)
        {
            // 일반 함수 있으니까 program 객체 먼저 만들자
            Program program = new Program();

            // 델리게이트 만들자
            ThreadStart t1 = new ThreadStart(program.Print);
            // 델리게이트 또 하나 써서 
            ThreadStart t2 = new ThreadStart(Program.sPrint);

            Thread th = new Thread(t1); // 스레드 하나 생성
            Thread th2 = new Thread(t2); // 스레드 하나 더 생성
                                         // unstart 상태

            // start상태
            th.Start(); // 스택이 하나 생성되고 그 스택에 program.Print 올려 놓고 자기는 종료(스타트 함수는 종료)
            th2.Start();// 스택이 하나 생성되고 그 스택에 Program.sPrint 올려 놓고 자기는 종료(스타트 함수는 종료)
            Console.WriteLine("나 메인이야 (나도 스레드)");


        }
    }
}