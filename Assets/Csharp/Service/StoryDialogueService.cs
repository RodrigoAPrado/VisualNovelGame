using System.Collections.Generic;
using System;
using UnityEngine;
using Csharp.Model.Dialogue;

namespace Csharp.Service
{
    public class StoryDialogueService
    {
        public string CurrentText { get; private set; }
        public string CurrentSpeaker { get; private set; }
        public string CurrentSpeakerTitle { get; private set; }
        public Color CurrentColor { get; private set;}

        public event Action DialogueSet;
        public event Action AwaitPlayerChoice;
        public event Action FinishPlayerChoice;

        private static StoryDialogueService instance;        

        private readonly Dictionary<string, Color> availableColors = new Dictionary<string, Color>{
            {"Blue" , new Color(0.51f, 0.38f, 0.81f)},
            {"Green", new Color(0.52f, 0.72f, 0.21f)},
            {"Default", new Color(1, 1, 1)}
        };

        private StoryDialogueService() {}

        public static StoryDialogueService GetInstance() {
            return instance ?? (instance = new StoryDialogueService());
        }

        public void SetDialogueData(DialogueLineModel dialogueData) {
            if(dialogueData.IsOptionsNext) {
                AwaitPlayerChoice?.Invoke();
            }

            CurrentText = dialogueData.Text;
            CurrentSpeaker = dialogueData.Speaker;
            CurrentSpeakerTitle = dialogueData.SpeakerTitle;
            CurrentColor = GetColor(dialogueData.TextColor);

            DialogueSet?.Invoke();
        }

        public void OnPlayerChoice() {
            FinishPlayerChoice?.Invoke();
        }

        private Color GetColor(string color) {
            return availableColors.ContainsKey(color) ? availableColors[color] : availableColors["Default"];
        }
    }
}