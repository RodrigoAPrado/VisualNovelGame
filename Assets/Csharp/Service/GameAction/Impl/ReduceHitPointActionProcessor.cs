using System.Collections.Generic;
using Csharp.Service.GameAction.Abstr;
using Csharp.Service.Super;

namespace Csharp.Service.GameAction.Impl
{
    public class ReduceHitPointActionProcessor : SingletonService<ReduceHitPointActionProcessor>, IActionProcessor
    {
        public ReduceHitPointActionProcessor() {
            ValidateSingleton();
        }

        public bool SetupActionAndCheckSkip(List<string> storyTags) {
            UnityEngine.Debug.Log("ReduceHitPointActionProcessor");
            return true; 
        }      
    }
}