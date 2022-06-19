namespace Hoonisone.ValueContainer2.Container.Tests
{

    public class Test
    {
        public delegate void F();

        public static bool IsErrorOccur(F f) // f를 실행하고 에러 발생 여부 반환
        {
            try { f(); }
            catch (System.Exception) { return true; }
            return false;
        }
    }
}