using System;

namespace Assignment1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "1234";
            int a;

            if (int.TryParse(test, out a))
                Console.WriteLine("정수로 변환 성공 : {0}", a);
            else
                Console.WriteLine("정수로 변환 실패 : {0}", a);
        }
        /*예제1) int.TryParse()에 대하여 조사하고 예를 1개 작성하기 바랍니다.
         * 
         *  int.TryParse 함수는 int.Parse와 마찬가지로 문자열을 원하는 정수로 변환하는 기능을 하는 함수이다.
         *  하지만 int.Parse와 다른 점은 변환 성공 여부를 리턴한다. 
         *  변환 성공시 true를 리턴하고, 실패 시 false를 리턴하는 bool타입이다.
         *  Parse()는 예외 처리 후, 프로그램 실행을 멈추고 흐름을 다른 곳으로 이동하지만 TryParse()는 변환의 성공여부를 반환하기 때문에 코드의 흐름을 유지할 수 있다.
         *  
         */
    }
}
