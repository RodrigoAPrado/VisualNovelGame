using System.Collections.Generic;
using Csharp.Service.Super;
using Csharp.Util;
using Csharp.Model.Item;

namespace Csharp.Service
{
    public class ItemLibraryService : SingletonService<ItemLibraryService>
    {
        private const string ItemsPath = "Data/Items/";

        private StoryService storyService;

        private ItemModel[] ItemLibrary;

        public ItemLibraryService() {
            ValidateSingleton();
            storyService = StoryService.GetInstance();
        }

        public void Setup () {
            storyService.OnStorySet += SetupItemLibrary;
        }

        private void SetupItemLibrary() {
            var itemLibraryString = FileReaderUtil.ReadFile(ItemsPath, storyService.StoryName + ".json", Enum.FilePathType.Absolute);
            ItemLibrary = UnityEngine.JsonUtility.FromJson<ItemListModel>(itemLibraryString).itemList;
        }
    }
}