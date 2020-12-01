using System.Collections.Generic;
using Csharp.Service.Super;
using Csharp.Util;
using Csharp.Model.Item;
using UnityEngine;

namespace Csharp.Service
{
    public class ItemLibraryService : SingletonService<ItemLibraryService>
    {
        private const string ItemsDataPath = "Data/Items/";
        private const string ItemsSpritePath = "Sprites/Items/";
        private const string ItemsBigSpritePath = ItemsSpritePath + "Big/";
        private const string ItemsSmallSpritePath = ItemsSpritePath + "Small/";

        private StoryService storyService;

        private ItemModel[] itemLibrary;

        public ItemLibraryService() {
            ValidateSingleton();
            storyService = StoryService.GetInstance();
        }

        public void Setup () {
            storyService.OnStorySet += SetupItemLibrary;
        }

        public ItemModel GetByNameAndVersion(string itemName, int itemVersion) {
            foreach(ItemModel itemModel in itemLibrary) {
                if(itemModel.storyVariableName.Equals(itemName) && itemModel.itemVersion == itemVersion) {
                    return itemModel;
                }
            }

            return null;
        }

        private void SetupItemLibrary() {
            var itemLibraryString = FileReaderUtil.ReadFile(ItemsDataPath, storyService.StoryName + ".json", Enum.FilePathType.Absolute);
            itemLibrary = UnityEngine.JsonUtility.FromJson<ItemListModel>(itemLibraryString).itemList;
            foreach(ItemModel itemModel in itemLibrary) {
                itemModel.SmallIcon = Resources.Load<Sprite>(ItemsSmallSpritePath + itemModel.smallIconPath);
                itemModel.BigIcon = Resources.Load<Sprite>(ItemsSmallSpritePath + itemModel.bigIconPath);
            }
        }
    }
}