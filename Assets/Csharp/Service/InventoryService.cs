using System.Diagnostics;
using System;
using System.Linq;
using System.Collections.Generic;
using Csharp.Service.Super;
using Csharp.Model.Item;

namespace Csharp.Service
{
    public class InventoryService : SingletonService<InventoryService> 
    {
        public ActiveItemIndex[] ActiveInventoryList => _activeInventoryList.ToArray();

        /**
         * Helps when building the item inventory screen to not rebuild it every time and only do it when the items themselves changed.
         */
        public int CurrentInventoryListChangeVersion { get; private set; } = 0;


        private const string InventoryListStoryVariableName = "inventory_list";
        private StoryService storyService;
        private string[] storyInventoryVariableList;


        /**
         * Item Name, item version.
         */
        private List<ActiveItemIndex> _activeInventoryList = new List<ActiveItemIndex>();

        public InventoryService() {
            ValidateSingleton();
            storyService = StoryService.GetInstance();
        }

        public void Setup () {
            storyService.OnStorySet += SetupInventoryList;
        }

        private void SetupInventoryList() {
            var storyInventoryListString = storyService.AccessStringStoryVariable(InventoryListStoryVariableName);
            storyInventoryVariableList = storyInventoryListString.Split(';');
            storyService.ObserveStoryVariables(storyInventoryVariableList, StoryInventoryChange);
            _activeInventoryList.Clear();
        }  

        private void StoryInventoryChange(string variableName, object newValue) {
            CurrentInventoryListChangeVersion++;
            var newItem = new ActiveItemIndex(variableName, Convert.ToInt32(newValue));

            if(newItem.ItemVersion > 0) {
                CheckAndInsertOrUpdateItem(newItem);
            }          
        }

        private void CheckAndInsertOrUpdateItem(ActiveItemIndex newItem) {
            foreach(ActiveItemIndex activeItem in _activeInventoryList) {
                if(activeItem.ItemName != newItem.ItemName) {
                    continue;
                }
                if(activeItem.ItemVersion < newItem.ItemVersion) {
                    activeItem.ItemVersion = newItem.ItemVersion;     
                } 
                return;
            } 
            _activeInventoryList.Add(newItem);   
        }
    }
}