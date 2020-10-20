using System.Data;
using System;
using System.Collections.Generic;
using Ink.Runtime;

namespace Csharp.Service
{
    public class OptionSelectService
    {
        private StoryService storyService;

        private StoryDialogueService storyDialogueService;

        private static OptionSelectService instance;

        public event Action SetupPlayerChoice;

        public event Action ClearPlayerChoice;

        private OptionSelectService() {
            storyService = StoryService.GetInstance();
            storyDialogueService = StoryDialogueService.GetInstance();
        }    

        public static OptionSelectService GetInstance() {
            return instance ?? (instance = new OptionSelectService());
        }

        public void Setup() {
            storyDialogueService.AwaitPlayerChoice += AwaitPlayerChoice;
            storyDialogueService.FinishPlayerChoice += FinishPlayerChoice;
        }

        public List<string> GetChoices() {
            List<string> choices = new List<string>();

            foreach(Choice c in storyService.StoryCurrentChoices) {
                choices.Add(c.text);
            }

            return choices;
        }

        public void SelectOption(int choiceIndex) {
            storyService.SelectOption(choiceIndex);
        }

        private void AwaitPlayerChoice() {
            SetupPlayerChoice?.Invoke();
        }

        private void FinishPlayerChoice() {
            ClearPlayerChoice?.Invoke();
        }
    }
}