using AsmdefDependencyPattern.DependenceeAbstruct;
using UnityEngine;
using Zenject;

namespace AsmdefDependencyPattern
{
    public class Main : MonoBehaviour
    {
        [Inject] IDependencee dependencee;

        void Start()
        {
            dependencee.DoSomething();
            Debug.Log(dependencee.GetCommonObject().value);
        }
    }
}
