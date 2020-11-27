using System.Dynamic;
using System.Diagnostics;
using System.Data;
using System;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using Csharp.Service.Super;

namespace Csharp.Service
{
    public class StoryService : SingletonService<StoryService> 
    {
        public List<Choice> StoryCurrentChoices => story.currentChoices; 

        public string StoryCurrentText => story.currentText;

        public List<string> StoryCurrentTags => story.currentTags;

        public bool CanStoryContinue => story.canContinue;

        public bool AwaitPlayerChoice => story.currentChoices?.Count > 0;

        private Story story;

        public event Action OnStorySet;

        public event Action OnStoryRead;

        public event Action OnPlayerChoice;

        public StoryService() {
            ValidateSingleton();
        }

        public void SetStory(string storyText) {
            story = new Story(storyText);
            OnStorySet?.Invoke();
        }

        public void AddStoryContinueListener(Action listener) {
            story.onDidContinue += listener;
        }

        public void ObserveStoryVariables(string[] variableNames, Story.VariableObserver action) {
            story.ObserveVariables(variableNames, action);
        }

        public void ResetStory() {
            story.ResetState();
        }

        public void ContinueStory() {
            if(story != null) {
                if(story.canContinue){
                    story.Continue();
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
        
        public bool AccessBoolStoryVariable(string variableName) {
            return story.variablesState.GetVariableWithName("inventory_list").ToString() == "true";
        }
        
        public string AccessStringStoryVariable(string variableName) {
            return story.variablesState.GetVariableWithName("inventory_list").ToString();
        }

        public int AccessIntStoryVariable(string variableName) {
            return Convert.ToInt32(story.variablesState.GetVariableWithName("inventory_list").ToString());
        }
    }
}