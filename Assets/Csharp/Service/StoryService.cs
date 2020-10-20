using System.Diagnostics;
using System.Data;
using System;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

namespace Csharp.Service
{
    public class StoryService
    {
        public List<Choice> StoryCurrentChoices => story.currentChoices; 

        public string StoryCurrentText => story.currentText;

        public List<string> StoryCurrentTags => story.currentTags;

        public bool CanStoryContinue => story.canContinue;

        public bool AwaitPlayerChoice => story.currentChoices?.Count > 0;

        private Story story;
        private static StoryService instance;

        public event Action OnStoryRead;

        public event Action OnPlayerChoice;

        private StoryService() {}

        public static StoryService GetInstance() 
        {
            return instance ?? (instance = new StoryService());
        }

        public void SetStory(string storyText) {
            story = new Story(storyText);
        }

        public void AddStoryContinueListener(Action listener) {
            story.onDidContinue += listener;
        }

        public void ResetStory() {
            story.ResetState();
        }

        public void ContinueStory() {
            if(story != null) {
                if(story.canContinue){
                    story.Continue();
                    UnityEngine.Debug.Log(story.currentText);
                    if(story.currentText == null || story.currentText.Length <= 0) {
                        ContinueStory();
                        return; 
                    }
                    OnStoryRead?.Invoke();
                    return;
                }
                throw new InvalidOperationException("Cannot continue story!");
            }
            throw new InvalidOperationException("Story has not been set!");
        }

        public void SelectOption(int choiceIndex) {
            story.ChooseChoiceIndex(choiceIndex);
            OnPlayerChoice?.Invoke();
        }
    }
}