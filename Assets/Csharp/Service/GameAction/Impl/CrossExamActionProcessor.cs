using System.Diagnostics;
using System.Collections.Generic;
using Csharp.Service.GameAction.Abstr;
using Csharp.Service.Super;

namespace Csharp.Service.GameAction.Impl
{
    public class CrossExamActionProcessor :  SingletonService<CrossExamActionProcessor>, IActionProcessor
    {
        public CrossExamActionProcessor() {
            ValidateSingleton();    
        }

        public bool SetupActionAndCheckSkip(List<string> storyTags) {
            UnityEngine.Debug.Log("CrossExamActionProcessor");
            return true; 
        }      
    }
}