# AsmdefDependencyPattern

A loosely coupled code is preferred.

The introduction of an anti-corruption layer and the Dependency Inversion Principle (DIP) protect your code from external library changes.

In Unity, you can separate assembly space by [Assembly definition](https://docs.unity3d.com/Manual/ScriptCompilationAssemblyDefinitionFiles.html).
It allows for more powerful layer separation

<img src="https://github.com/naninunenoy/AsmdefDependencyPattern/blob/master/doc/AsmdefDependencyPattern.png?raw=true" width="600" />

`Main` has `IDependencee` object to do something. Unity life cycle will call `Main.Start()` and `DoSomething()`.

```c#
public class Main : MonoBehaviour
{
    [Inject] IDependencee dependencee;

    void Start()
    {
        dependencee.DoSomething();
        Debug.Log(dependencee.GetCommonObject().value);
    }
}
```

___

`Main` does not know implemention of `IDependencee`. It means changing `Dependency` implemention do not effect `Main`.

<img src="https://user-images.githubusercontent.com/15327448/82117401-ac597600-97aa-11ea-8736-6c7d3a8ce6ca.png" width="200" />

In addition, *Dependencer.asmdef* does not refer *DependenceeImplement.asmdef* so you can not even construct `Dependencee` object in `Main`.

*Dependencer.asmdef* refers to *DependenceeAbstruct.asmdef*. This is  anti-corruption layer assembly space and contains only interfaces that define the behavior.
```c#
namespace AsmdefDependencyPattern.DependenceeAbstruct
{
    public interface IDependencee
    {
        void DoSomething();
        Common GetCommonObject();
    }
}
```

Of course, *DependenceeImplement.asmdef* refers to *DependenceeAbstruct.asmdef* to implement interfaces.
```c#
namespace AsmdefDependencyPattern.DependenceeImplement
{
    public class Dependencee : DependenceeAbstruct.IDependencee
    {
        public void DoSomething()
        {
            UnityEngine.Debug.Log("Dependencee.DoSomething()");
        }

        public Common GetCommonObject()
        {
            return new Common {value = 999};
        }
    }
}
```

___

Wait, how and who provide `Dependencee` object to `Main`?

The answer is Dependency  Injection(DI).

<img src="https://user-images.githubusercontent.com/15327448/82117554-b039c800-97ab-11ea-906d-da3ef9084137.png" width="450" />

[Zenject](https://github.com/svermeulen/Extenject) is DI framework wroks on Unity. If `IDependencee` is requested, set it to return an instance of `Dependencee`.

```c#
public class DependenceIntermediary : Zenject.MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IDependencee>().To<Dependencee>().AsTransient();
    }
}
```

*DependenceIntermediary.asmdef* refers to both *DependenceeAbstruct.asmdef* and *DependenceeImplement.asmdef* to resolove dependency.

And `Zenject.SceneContext` will resolove dependency between `IDependencee` and `Dependencee` in scene, before `Main.Awake()` called.

___

Do you need a class to traverse these layers?

In order to refer from these assembly spaces, you need to create a new assembly space and define class there.

<img src="https://user-images.githubusercontent.com/15327448/82117919-9c439580-97ae-11ea-93b5-eb46afce553c.png" width="300" />

*Common.asmdef* does not refer to an assembly, but it is referred to by 3 assemblies.

The Assembly definition help you strictly separate the layers within your Unity project.

see also: https://github.com/naninunenoy/UnityCleanArchitectureExample


## Auther
[@naninunenoy](https://github.com/naninunenoy)
