using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Ex06_Process_Thread_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            Process proc = Process.GetCurrentProcess();
            string Processname = proc.ProcessName;
            DateTime startTime = proc.StartTime;
            int proid = proc.Id;
            Console.WriteLine("[현재 프로세스 정보 출력]");
            Console.WriteLine("{0} - {1} - {2}", Processname, startTime, proid);
            Console.WriteLine(proc.HasExited); // 연결된 프로세스가 종료 되었는지 (종료되면 true)

            //문제 : Process.GetProcesses();
            // OS에서 돌고 있는 모든 프로세스
            
            Process[] pros = Process.GetProcesses();

            Console.WriteLine("[전체 프로세스 정보]");
            foreach (Process p in pros)
            {
                Console.WriteLine("{0}", p.ProcessName);
            }
            

        }
    }
}