using System;
using System.Linq;
using System.Collections.Generic;
using Csharp.Service.Super;

namespace Csharp.Service
{
    public class InventoryService : SingletonService<InventoryService> 
    {
        public string[] ActiveInventoryList {
            get => _activeInventoryList.ToArray();
        }

        private const string InventoryListStoryVariableName = "inventory_list";
        private StoryService storyService;
        private string[] storyInventoryList;
        private List<string> _activeInventoryList = new List<string>();

        public InventoryService() {
            ValidateSingleton();
            storyService = StoryService.GetInstance();
        }

        public void Setup () {
            storyService.OnStorySet += SetupInventoryList;
        }

        private void SetupInventoryList() {
            var storyInventoryListString = storyService.AccessStringStoryVariable(InventoryListStoryVariableName);
            storyInventoryList = storyInventoryListString.Split(';');
            storyService.ObserveStoryVariables(storyInventoryList, StoryInventoryChange);
            _activeInventoryList.Clear();
        }  

        private void StoryInventoryChange(string variableName, object newValue) {
            var itemState = newValue.ToString() == "1";
            if(itemState && !_activeInventoryList.Contains(variableName)) {
                _activeInventoryList.Add(variableName);
            }          
        }
    }
}