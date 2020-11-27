using System.Collections.Generic;
using Csharp.Service.GameAction.Abstr;
using Csharp.Service.Super;

namespace Csharp.Service.GameAction.Impl
{
    public class PresentActionProcessor : SingletonService<PresentActionProcessor>, IActionProcessor
    {
        public PresentActionProcessor() {
            ValidateSingleton();
        }
        
        public bool SetupActionAndCheckSkip(List<string> storyTags) {
            return true; 
        }      
    }
}