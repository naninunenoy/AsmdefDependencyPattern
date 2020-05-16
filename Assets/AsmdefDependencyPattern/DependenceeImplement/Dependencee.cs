using AsmdefDependencyPattern.DependenceeAbstruct;

namespace AsmdefDependencyPattern.DependenceeImplement
{
    public class Dependencee : IDependencee
    {
        public void DoSomething()
        {
            UnityEngine.Debug.Log("Dependencee.DoSomething()");
        }
    }
}
