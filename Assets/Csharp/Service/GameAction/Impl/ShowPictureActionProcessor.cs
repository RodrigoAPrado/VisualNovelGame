using System.Collections.Generic;
using Csharp.Service.GameAction.Abstr;
using Csharp.Service.Super;

namespace Csharp.Service.GameAction.Impl
{
    public class ShowPictureActionProcessor : SingletonService<ShowPictureActionProcessor>, IActionProcessor
    {
        public ShowPictureActionProcessor() {
            ValidateSingleton();
        }
        
        public bool SetupActionAndCheckSkip(List<string> storyTags) {
            return true; 
        }      
    }
}