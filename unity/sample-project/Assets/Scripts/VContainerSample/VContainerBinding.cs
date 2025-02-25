using UnityEngine;
using VContainer;

public class VContainerBinding : MonoBehaviour
{
    // ここは Inject が必要
    [Inject] private readonly IClassA classA;

    private void Awake()
    {
        Debug.Log("VContainerBinding Awake()");
        classA.MethodA();
    }
}

public interface IClassA
{
    void MethodA();
}

public class ClassA : IClassA
{
    // Inject されたクラスの依存関係にあたるクラスには [Inject] 属性は不要
    IClassB _classB;
    public ClassA(IClassB classB)
    {
        _classB = classB;
    }
    public void MethodA()
    {
        Debug.Log("MethodA() called");
        _classB.MethodB();
    }
}

public interface IClassB
{
    void MethodB();
}

public class ClassB : IClassB
{
    public void MethodB()
    {
        Debug.Log("MethodB() called");
    }
}