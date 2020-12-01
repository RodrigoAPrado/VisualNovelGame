using System;
using UnityEngine;
namespace Csharp.Model.Item
{
    [SerializableAttribute]
    public class ItemModel
    {
        public string StoryChoiceOption => storyVariableName ?? storyVariableName.Replace("_", "-");
        public bool HasDetails => details !=  null;
        public Sprite SmallIcon {get;set;}
        public Sprite BigIcon {get;set;}
        public string writtenName;
        public string storyVariableName;
        public int itemVersion;
        public string bigIconPath;
        public string smallIconPath;
        public string itemDescription;
        [SerializeField]
        public ItemDetailsModel details;
    }
}