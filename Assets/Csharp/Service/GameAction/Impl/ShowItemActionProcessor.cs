using System.Collections.Generic;
using Csharp.Service.GameAction.Abstr;
using Csharp.Service.Super;

namespace Csharp.Service.GameAction.Impl
{
    public class ShowItemActionProcessor : SingletonService<ShowItemActionProcessor>, IActionProcessor
    {
        public ShowItemActionProcessor() {
            ValidateSingleton();
        }

        public bool SetupActionAndCheckSkip(List<string> storyTags) {
            return true; 
        }      
    }
}