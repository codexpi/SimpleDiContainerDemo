
namespace SimpleDiContainer.Lib
{
    internal class InstanceHub
    {
        internal Type Type { get; set; }
        internal LifeTime LifeTime { get; set; }
        internal object? Instance { get; set; }
        internal bool IsNewScope { get; set; }
        internal InstanceHub(LifeTime lifeTime,Type type)
        {
            Type=type;
            LifeTime=lifeTime;
            IsNewScope=true;
        }
    }
}
