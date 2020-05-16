using AsmdefDependencyPattern.DependenceeAbstruct;
using AsmdefDependencyPattern.DependenceeImplement;
using Zenject;

namespace AsmdefDependencyPattern.DependenceIntermediary
{
    public class DependenceIntermediary : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IDependencee>().To<Dependencee>().AsTransient();
        }
    }
}
