using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Csharp.Model.Item;

public class ItemButtonController : MonoBehaviour
{
    public Button itemClickable;
    public Image itemIcon;
    private InventoryScreenController inventoryScreenController;
    private ItemModel itemModel;

    void Awake() {
        inventoryScreenController = GameObject.FindGameObjectWithTag("InventoryScreenController").GetComponent<InventoryScreenController>();
    }

    public void SetItemModel(ItemModel newItemModel) {
        itemModel = newItemModel;
        itemIcon.sprite = itemModel.SmallIcon;
    }

    public void OnClickableEvent() {
        
    }

}
