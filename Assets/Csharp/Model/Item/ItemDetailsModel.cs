using System;
namespace Csharp.Model.Item
{
    [SerializableAttribute]
    public class ItemDetailsModel
    {
        public enum ItemDetailType {
            Text, Image
        }

        public ItemDetailType type;
        public int pages;
        public int paragraphPerPages;
        public string[] text;
    }
}