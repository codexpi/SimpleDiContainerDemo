
namespace SimpleDiContainer.Lib
{
    public class DiContainer
    {
        private static Dictionary<Type, InstanceHub> services=new();
        //internal static Dictionary<Type, InstancePot> Services { get { return services; } }
        internal static void AddInstance(Type type, InstanceHub instancePot)
        {
            services[type] = instancePot;
        }
        //internal DiContainer(Dictionary<Type, InstancePot> services)
        //{
        //    DiContainer.services = services;
        //}
        private void Validate<TAbstract>()
        {
            if (services == null)
            {
                throw new Exception("No type is registered in DI container.");
            }
            Type typeAbstract = typeof(TAbstract);
            if (!services.ContainsKey(typeAbstract))
            {
                throw new Exception("Type " + typeAbstract.Name + " is not registered in DI container.");
            }
        }
        public TAbstract GetService<TAbstract>()
        {
            Validate<TAbstract>();
            Type typeAbstract = typeof(TAbstract);
            InstanceHub instanceHub = services[typeAbstract];
            LifeTime lifeTime = instanceHub.LifeTime;
            Type typeConcrete = instanceHub.Type;
            if (lifeTime == LifeTime.Singleton)
            {
                if (instanceHub.Instance == null)
                {
                    instanceHub.Instance = Activator.CreateInstance(typeConcrete);
                }
            }
            else if(lifeTime == LifeTime.Scoped)
            {
                if (instanceHub.IsNewScope)
                {
                    instanceHub.IsNewScope = false;
                    instanceHub.Instance = Activator.CreateInstance(typeConcrete);
                }
            }
            else
            {
                instanceHub.Instance = Activator.CreateInstance(typeConcrete);
            }
            if (instanceHub.Instance == null) { throw new Exception("Type is not instanciated."); }
            return (TAbstract)instanceHub.Instance;
        }

        public void ChangeScope<TAbstract>()
        {
            Validate<TAbstract>();
            Type typeAbstract = typeof(TAbstract);
            InstanceHub instanceHub = services[typeAbstract];
            instanceHub.IsNewScope= true;
        }
    }
}
