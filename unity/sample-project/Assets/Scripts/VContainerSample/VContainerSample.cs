using VContainer;
using VContainer.Unity;

public class VContainerSample : LifetimeScope
{
    // VContainerBinding を SerializeField の Auto Inject Game Objects に設定する点に注意!! 
    protected override void Configure(IContainerBuilder builder)
    {
        // ClassA のインスタンスを IClassA 型で返す
        builder.Register<IClassA, ClassA>(Lifetime.Singleton);
        builder.Register<IClassB, ClassB>(Lifetime.Singleton);
    }
}
