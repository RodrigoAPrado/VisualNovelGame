using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Csharp.Model.Dialogue;
using Csharp.Service.Super;

namespace Csharp.Service
{
    public class StoryReadingService : SingletonService<StoryReadingService>
    {
        private const string ActionTag = "Action:";
        private const string ColorTag = "Color:";
        private const string OptionModeTag = "OptionMode:";
        private const string SpeakerTag = "Speaker:";
        private const string SpeakerTitleTag = "SpeakerTitle:";

        private StoryService storyService;

        private StoryDialogueService storyDialogueService;

        private ActionProcessService actionProcessService;

        public StoryReadingService() {
            ValidateSingleton();
            storyService = StoryService.GetInstance();
            storyDialogueService = StoryDialogueService.GetInstance();
            actionProcessService = ActionProcessService.GetInstance();
            
        }

        public void Setup(string storyName, string storyText) {
            storyService.SetStory(storyName, storyText);
            storyService.OnStoryRead += OnStoryRead;
            storyService.OnPlayerChoice += OnPlayerChoice;
        }

        public void BeginReadingStory() {
            storyService.ResetStory();
            storyService.ContinueStory();    
        }

        public void NextDialogue() {
            storyService.ContinueStory();
        }  

        private void OnStoryRead() {
            var storyTags = storyService.StoryCurrentTags;
            if(CheckActionAndSkipDialogue(storyTags)) {
                NextDialogue();
                return;
            }

            var dialogueData = new DialogueLineModel();

            dialogueData.Text = storyService.StoryCurrentText;
            dialogueData.Speaker = GetTagData(storyTags, SpeakerTag);
            dialogueData.SpeakerTitle = GetTagData(storyTags, SpeakerTitleTag);
            dialogueData.TextColor = GetTagData(storyTags, ColorTag);
            dialogueData.IsOptionsNext = storyService.AwaitPlayerChoice;
            dialogueData.OptionMode = GetTagData(storyTags, OptionModeTag);

            storyDialogueService.SetDialogueData(dialogueData);
        }

        private void OnPlayerChoice() {
            storyDialogueService.OnPlayerChoice();
            storyService.ContinueStory();
        }

        private string GetTagData(List<string> storyTags, string dataParam) {
            var data = storyTags.FirstOrDefault(it => it.Contains(dataParam));
            if(data == null) {
                return "";
            }
            return data.Split(':')[1];        
        }

        private bool CheckActionAndSkipDialogue(List<string> storyTags) {
            var storyAction = GetTagData(storyTags, ActionTag);
            if(storyAction.Length <= 0) {
                return false;
            }

            return actionProcessService.ProcessActionAndCheckSkipDialogue(storyAction, storyTags);
        }    
    }
}