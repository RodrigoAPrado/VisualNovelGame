using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Csharp.Service
{
    public class StoryReadingService
    {
        private const string SpeakerTag = "Speaker:";
        private const string SpeakerTitleTag = "SpeakerTitle:";
        private const string ActionTag = "Action:";
        private const string ColorTag = "Color:";

        private static StoryReadingService instance;

        private StoryService storyService;

        private StoryDialogueService storyDialogueService;

        private StoryReadingService() {
            storyService = StoryService.GetInstance();
            storyDialogueService = StoryDialogueService.GetInstance();
        }

        public static StoryReadingService GetInstance() {
            return instance ?? (instance = new StoryReadingService());
        } 

        public void Setup(string storyText) {
            storyService.SetStory(storyText);
            storyService.OnStoryRead += OnStoryRead;
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
            var storyAction = GetTagData(storyTags, ActionTag);
            if(storyAction.Length > 0) {
                // Do something
                return;
            }

            var storyText = storyService.StoryCurrentText;
            var storySpeaker = GetTagData(storyTags, SpeakerTag);
            var storySpeakerTitle = GetTagData(storyTags, SpeakerTitleTag);
            var storyColor = GetTagData(storyTags, ColorTag);

            storyDialogueService.SetDialogueData(storyText, storySpeaker, storySpeakerTitle, storyColor);
        }

        private string GetTagData(List<string> storyTags, string dataParam) {
            var data = storyTags.FirstOrDefault(it => it.Contains(dataParam));
            if(data == null) {
                return "";
            }
            return data.Split(':')[1];        
        }
    }
}