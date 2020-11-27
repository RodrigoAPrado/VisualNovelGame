using System.Collections.Generic;
using Csharp.Service.GameAction.Abstr;
using Csharp.Service.Super;

namespace Csharp.Service.GameAction.Impl
{
    public class PressActionProcessor : SingletonService<PressActionProcessor>, IActionProcessor
    {
        public PressActionProcessor() {
            ValidateSingleton();
        }
        
        public bool SetupActionAndCheckSkip(List<string> storyTags) {
            return true; 
        }      
    }
}