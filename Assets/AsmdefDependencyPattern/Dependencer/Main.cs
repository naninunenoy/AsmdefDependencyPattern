using AsmdefDependencyPattern.DependenceeAbstruct;
using UnityEngine;
using Zenject;

namespace AsmdefDependencyPattern.Dependencer
{
    public class Main : MonoBehaviour
    {
        [Inject] IDependencee dependencee;

        void Start()
        {
            dependencee.DoSomething();
        }
    }
}
