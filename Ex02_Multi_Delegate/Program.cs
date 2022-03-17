using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Multi_Delegate
{
    delegate void MulDel(string str);
    delegate string MulDel2(string str);
    delegate int MulDel3(int x, int y);

    class Test
    {
        public void mul_1(string str)
        {
            Console.WriteLine("1번 : {0}", str);
        }
        public void mul_2(string str)
        {
            Console.WriteLine("2번 : {0}", str);
        }
        public string mul_3(string str)
        {
            return "결과 : " + str;
        }

        public int mul_4(int x, int y)
        {
            return x + y;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            MulDel m = new MulDel(t.mul_1); // t.mul_1을 대리한다
            MulDel m2 = new MulDel(t.mul_2); // t.mul_2을 대리한다
            //m("출발");
            //m2("나도 출발"); // 형식이 같으면 멀티 델리게이트 써보자

            // 단 조건은 형식이 같아야 한다
            MulDel m3;
            m3 = m; // m3이라는 델리게이트 타입이 m1, m2랑 동일하니까 (m3이 m 함수의 주소를 가짐)
            m3 += m2; // 이게 가능하다!!! (하나의 델리게이트가 여러 개(m1,m2)의 같은 타입의 함수를 대리할 수 있다.)

            m3("전체 출발");

            MulDel3 m4 = new MulDel3(t.mul_4);
            int result = m4(10, 20);
            Console.WriteLine(result);
        }
    }
}