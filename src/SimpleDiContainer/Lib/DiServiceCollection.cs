
namespace SimpleDiContainer.Lib
{
    /// <summary>
    /// This class <c>(DiServiceCollection)</c> is to 
    /// <list type="bullet">
    /// <item>
    /// <description>Assign concrete class for an interface (abstraction) to create instance of a class.</description>
    /// </item>
    /// <item>
    /// <description>Get instance when required.</description>
    /// </item>
    /// <item>
    /// <description>Assign class to create object as it's lifetime: Transient, Singletone and Scoped.</description>
    /// </item>
    /// </list>
    /// </summary>
    public class DiServiceCollection
    {
        /// <summary>
        /// To add instance for lifetime Transient into DI container.
        /// </summary>
        /// <typeparam name="TAbstract"></typeparam>
        /// <typeparam name="TConcrete"></typeparam>
        public void AddTransient<TAbstract, TConcrete>()
        {
            Type typeAbstract= typeof(TAbstract);
            Type typeConcrete= typeof(TConcrete);
            InstanceHub instanceHub= new InstanceHub(LifeTime.Transient, typeConcrete);
            DiContainer.AddInstance(typeAbstract, instanceHub);
        }
        /// <summary>
        /// To add instance for lifetime Singletone into DI container.
        /// </summary>
        /// <typeparam name="TAbstract"></typeparam>
        /// <typeparam name="TConcrete"></typeparam>
        public void AddSingleTon<TAbstract, TConcrete>()
        {
            Type typeAbstract = typeof(TAbstract);
            Type typeConcrete = typeof(TConcrete);
            InstanceHub instancePot = new InstanceHub(LifeTime.Singleton, typeConcrete);
            DiContainer.AddInstance(typeAbstract, instancePot);
        }

        /// <summary>
        /// To add instance for lifetime Scopped into DI container. Scope will be changed by calling diContainer.ChangeScope<TAbstract>.
        /// </summary>
        /// <typeparam name="TAbstract"></typeparam>
        /// <typeparam name="TConcrete"></typeparam>
        public void AddScoped<TAbstract, TConcrete>()
        {
            Type typeAbstract = typeof(TAbstract);
            Type typeConcrete = typeof(TConcrete);
            InstanceHub instancePot = new InstanceHub(LifeTime.Scoped, typeConcrete);
            DiContainer.AddInstance(typeAbstract, instancePot);
        }
        public DiContainer DiContainer { get { return new DiContainer(); } }
    }
}
