using System.Collections.Generic;
using System;
using UnityEngine;

namespace Csharp.Service
{
    public class StoryDialogueService
    {
        public string CurrentText { get; private set; }
        public string CurrentSpeaker { get; private set; }
        public Color CurrentColor { get; private set;}

        public event Action DialogueSet;

        private static StoryDialogueService instance;        

        private readonly Dictionary<String, Color> availableColors = new Dictionary<string, Color>{
            {"Blue" , new Color(0, 0.1f, 0.6f)},
            {"Green", new Color(0, 0.6f, 0.1f)},
            {"Default", new Color(0.25f, 0.25f, 0.25f)}
        };

        private StoryDialogueService() {}

        public static StoryDialogueService GetInstance() {
            return instance ?? (instance = new StoryDialogueService());
        }

        public void SetDialogueData(string text, string speaker, string color) {
            CurrentText = text;
            CurrentSpeaker = speaker;
            CurrentColor = GetColor(color);

            DialogueSet?.Invoke();
        }

        private Color GetColor(string color) {
            return availableColors.ContainsKey(color) ? availableColors[color] : availableColors["Default"];
        }
    }
}