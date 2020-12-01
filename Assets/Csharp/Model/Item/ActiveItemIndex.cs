namespace Csharp.Model.Item
{
    public class ActiveItemIndex
    {
        public ActiveItemIndex(string itemName, int itemVersion) {
            ItemName = itemName;
            ItemVersion = itemVersion;
        }
        public string ItemName {get; set;}
        public int ItemVersion {get; set;}   
    }
}