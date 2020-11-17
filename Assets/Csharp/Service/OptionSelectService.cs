using System.Diagnostics;
using System.Data;
using System;
using System.Collections.Generic;
using Ink.Runtime;
using Csharp.Service.Super;

namespace Csharp.Service
{
    public class OptionSelectService : SingletonService<OptionSelectService>
    {
        private StoryService storyService;

        private StoryDialogueService storyDialogueService;

        public event Action SetupPlayerChoice;

        public event Action ClearPlayerChoice;

        public event Action SetupCrossExam;

        public OptionSelectService() {
            ValidateSingleton();
            storyService = StoryService.GetInstance();
            storyDialogueService = StoryDialogueService.GetInstance();
        }    

        public void Setup() {
            storyDialogueService.AwaitPlayerChoice += AwaitPlayerChoice;
            storyDialogueService.FinishPlayerChoice += FinishPlayerChoice;
            storyDialogueService.AwaitCrossExamChoice += AwaitCrossExamChoice;
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

        private void AwaitCrossExamChoice() {
            SetupCrossExam?.Invoke();
        }

        private void FinishPlayerChoice() {
            ClearPlayerChoice?.Invoke();
        }
    }
}