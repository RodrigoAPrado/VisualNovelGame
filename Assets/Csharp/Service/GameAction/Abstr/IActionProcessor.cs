using System.Collections.Generic;

namespace Csharp.Service.GameAction.Abstr
{
    public interface IActionProcessor
    {
        bool SetupActionAndCheckSkip(List<string> storyTags);     
    }
}