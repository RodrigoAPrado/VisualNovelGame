using System;
using UnityEngine;
namespace Csharp.Model.Item
{
    [SerializableAttribute]
    public class ItemModel
    {
        public string StoryChoiceOption => storyVariablaName ?? storyVariablaName.Replace("_", "-");
        public bool HasDetails => details !=  null;
        public string writtenName;
        public string storyVariablaName;
        public string itemVersion;
        public string bigIconPath;
        public string smallIconPath;
        public string itemDescription;
        
        [SerializeField]
        public ItemDetailsModel details;
    }
}