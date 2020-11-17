using System;
using System.Collections.Generic;
using Csharp.Service.GameAction.Abstr;
using Csharp.Service.GameAction.Impl;
using Csharp.Util;
using Csharp.Service.Super;

namespace Csharp.Service
{
    public class ActionProcessService : SingletonService<ActionProcessService>
    {
        private const string ActionTypeCrossExam = "cross-exam";
        private const string ActionTypeOpeningTransit = "opening-transit";
        private const string ActionTypePresent = "present";
        private const string ActionTypePress = "press";
        private const string ActionTypeReduceHitPoint = "reduce-hit-point";
        private const string ActionTypeShowItem = "show-item";
        private const string ActionTypeShowPicture = "show-picture";
        private const string ActionTypeTestimonyTransit = "testimony-transit";

        private Dictionary<string, IActionProcessor> actionProcessorDictionary;

        public ActionProcessService() {
            ValidateSingleton();
            actionProcessorDictionary = SetupActionProcessorDictionary();     
        }

        public bool ProcessActionAndCheckSkipDialogue(string actionName, List<string> storyTags) {
            try {
                return actionProcessorDictionary[actionName].SetupActionAndCheckSkip(storyTags);
            } catch (KeyNotFoundException) {
                throw new Exception("Action name not found: " + actionName);
            }  
        }    

        private static Dictionary<string, IActionProcessor> SetupActionProcessorDictionary() {
            var result = new Dictionary<string, IActionProcessor>();
            
            result.Add(ActionTypeCrossExam, CrossExamActionProcessor.GetInstance());
            result.Add(ActionTypeOpeningTransit, OpeningTransitActionProcessor.GetInstance());
            result.Add(ActionTypePresent, PresentActionProcessor.GetInstance());
            result.Add(ActionTypePress, PressActionProcessor.GetInstance());
            result.Add(ActionTypeReduceHitPoint, ReduceHitPointActionProcessor.GetInstance());
            result.Add(ActionTypeShowItem, ShowItemActionProcessor.GetInstance());
            result.Add(ActionTypeShowPicture, ShowPictureActionProcessor.GetInstance());
            result.Add(ActionTypeTestimonyTransit, TestimonyTransitActionProcessor.GetInstance());

            return result;
        }
    }
}