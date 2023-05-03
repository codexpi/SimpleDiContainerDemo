
using SimpleDiContainer.Lib;

namespace AppDemo.Test
{
    public class TestOne
    {
        public void Test00()
        {
            // Getting DI Service Collection.
            DiServiceCollection services=new DiServiceCollection();

            // Getting DI Container.
            DiContainer container = services.DiContainer;
            IHelloWorld helloWorld;

            Console.WriteLine("Singleton");
            services.AddSingleTon<IHelloWorld, HelloWorld>();

            helloWorld = container.GetService<IHelloWorld>();
            helloWorld.Print("Singleton 01");

            helloWorld = container.GetService<IHelloWorld>();
            helloWorld.Print("Singleton 02");

            helloWorld = container.GetService<IHelloWorld>();
            helloWorld.Print("Singleton 03");
            Console.WriteLine("--");


            Console.WriteLine("Scoped");
            services.AddScoped<IHelloWorld, HelloWorld>();

            helloWorld = container.GetService<IHelloWorld>();
            helloWorld.Print("Scoped 01");

            helloWorld = container.GetService<IHelloWorld>();
            helloWorld.Print("Scoped 02");

            container.ChangeScope<IHelloWorld>();
            Console.WriteLine("Changed Scope");
            helloWorld = container.GetService<IHelloWorld>();
            helloWorld.Print("Scoped 03");
            Console.WriteLine("--");


            Console.WriteLine("Transient");
            services.AddTransient<IHelloWorld, HelloWorld>();

            helloWorld = container.GetService<IHelloWorld>();
            helloWorld.Print("Transient 01");

            helloWorld = container.GetService<IHelloWorld>();
            helloWorld.Print("Transient 02");

            helloWorld = container.GetService<IHelloWorld>();
            helloWorld.Print("Transient 03");

            Console.Write("\nPres any key to close... ");
            Console.ReadKey();
        }
        
    }
}
