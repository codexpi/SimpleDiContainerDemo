
namespace AppDemo.Test
{
    public class HelloWorld : IHelloWorld
    {
        private string guid;
        public HelloWorld()
        {
            this.guid = Guid.NewGuid().ToString();
        }
        public void Print(string msg)
        {
            Console.WriteLine(msg+" >> Guid = "+guid);
        }
    }
}
