using System.Collections.Generic;
using Csharp.Service.GameAction.Abstr;
using Csharp.Service.Super;

namespace Csharp.Service.GameAction.Impl
{
    public class OpeningTransitActionProcessor : SingletonService<OpeningTransitActionProcessor>, IActionProcessor
    {
        public OpeningTransitActionProcessor() {
            ValidateSingleton();
        }

        public bool SetupActionAndCheckSkip(List<string> storyTags) {
            UnityEngine.Debug.Log("OpeningTransitActionProcessor");
            return true; 
        }      
    }
}