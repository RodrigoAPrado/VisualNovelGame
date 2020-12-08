using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Csharp.Model.Item;

public class ItemButtonController : MonoBehaviour
{
    public ItemModel ItemModel => itemModel;
    public Button itemClickable;
    public Image itemIcon;
    private InventoryScreenController inventoryScreenController;
    private ItemModel itemModel;

    private int index;

    void Awake() {
        inventoryScreenController = GameObject.FindGameObjectWithTag("InventoryScreenController").GetComponent<InventoryScreenController>();
    }

    public void SetItemModel(ItemModel newItemModel) {
        itemModel = newItemModel;
        itemIcon.sprite = itemModel.SmallIcon;
    }

    public void SetIndex(int newIndex) {
        index = newIndex;   
    }

    public void OnClickableEvent() {
        inventoryScreenController.SelectItem(index);           
    }

}
