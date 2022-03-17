using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_Event_Delegate
{

    delegate void onClick(string what); // 델리게이트 타입(void, parameter(string)) 대리자

    class TestDel
    {
        public void MouseClick(string what)
        {
            Console.WriteLine("마우스의 {0} 버튼이 클릭", what);
        }

        public void KeyboardClick(string what)
        {
            Console.WriteLine("키보드의 {0} 자판이 클릭", what);
        }
    }


    class Program
    {

        public event onClick myCLick; // 이벤트 onClick 델리게이트 형식을 [이벤트 핸들러]로 가진다
        static void Main(string[] args)
        {
            TestDel testDel = new TestDel();
            Program m = new Program();

            m.myCLick += new onClick(testDel.MouseClick); // myClick 이라는 이벤트가 발생하면 OnClick이라는 델리게이트를 통해서 등록된이 벤트 핸들러를 호출하겠다 
            // testDel.MouseClick -> 핸들러로 등록되는 함수의 형식은 onClick 이라는 형식과 동일해야 함
            // m.myCLick -= new onClick(testDel.MouseClick);
            m.myCLick += new onClick(testDel.KeyboardClick); // myClick 이라는 이벤트가 발생하면 OnClick이라는 델리게이트를 통해서 등록된이 벤트 핸들러를 호출하겠다 

            m.myCLick("왼쪽");
        }
    }
}