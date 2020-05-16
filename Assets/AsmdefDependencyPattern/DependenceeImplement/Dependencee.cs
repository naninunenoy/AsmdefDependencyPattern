using AsmdefDependencyPattern.DependenceeAbstruct;

namespace AsmdefDependencyPattern.DependenceeImplement
{
    public class Dependencee : IDependencee
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
