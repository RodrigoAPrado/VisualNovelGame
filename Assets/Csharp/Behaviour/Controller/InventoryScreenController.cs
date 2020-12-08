using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Csharp.Service;
using Csharp.Model.Item;

public class InventoryScreenController : MonoBehaviour
{
    public ItemModel ItemSelected => currentInventoryItems[currentSelectedItem].ItemModel;
    public GameObject itemButtonPrefab;
    public Transform itemButtonsGroup;
    public GameObject inventoryOverlay;
    public GameObject inventoryScreen;
    public GameObject profileScreen;
    public GameObject inventoryCloseButton;
    public GameObject presentButton;
    public ItemSelectedController itemSelectedController;
    private InventoryService inventoryService;
    private ItemLibraryService libraryService;
    private int lastInventoryListChangeVersion;
    private ItemButtonController[] currentInventoryItems;
    private int itemButtonSpacing = 162;
    private int itemButtonDefaultX = -730;
    private int itemButtonDefaultY = -118;
    private int itemButtonPageSize = 10;
    private int currentItemPage = 0;
    private int finalPage = 0;
    private int currentSelectedItem = 0;

    public InventoryScreenController() {
        inventoryService = InventoryService.GetInstance();
        libraryService = ItemLibraryService.GetInstance();
    }

    void Awake() {
        lastInventoryListChangeVersion = inventoryService.CurrentInventoryListChangeVersion - 1;
        inventoryService.Setup();
        libraryService.Setup();
        DeactivateInventoryScreen();
    }

    public void ShowItemScreen() {
        BuildCurrentItemButtons();     
        inventoryOverlay.SetActive(true);   
        inventoryCloseButton.SetActive(true);
        inventoryScreen.SetActive(true);
        presentButton.SetActive(true);
        itemSelectedController.gameObject.SetActive(true);
        InitializeItemButtons();
    }

    public void SwitchPage(int nextVal) {
        if(nextVal != -1 && nextVal != 1) {
            return;
        }
        int nextPage = currentItemPage + nextVal;
        if(nextPage < 0) {
            nextPage = finalPage; 
        } else if(nextPage > finalPage) {
            nextPage = 0;
        }
        ToggleItemButtonsByPage(false);
        currentItemPage = nextPage;
        ToggleItemButtonsByPage(true);
    }

    public void HideItemScreen() {
        DeactivateInventoryScreen();
    }
    
    public void SelectItem(int itemIndex, bool forceSelect = false) {
        if(currentSelectedItem == itemIndex && !forceSelect) {
            return;
        }
        currentSelectedItem = itemIndex;
        itemSelectedController.SetSelectedItem(ItemSelected);
    }

    private void HideItemButtons() {
        if(currentInventoryItems == null) {
            return;
        }
        foreach(ItemButtonController itemButton in currentInventoryItems) {
            if(itemButton != null) {
                itemButton.gameObject.SetActive(false);
            }
        }
    }

    private void ToggleItemButtonsByPage(bool toggle){
        int itemIndex = currentItemPage * itemButtonPageSize;
        int finalItemIndex = itemIndex + itemButtonPageSize - 1;
        while(itemIndex <= finalItemIndex && itemIndex < currentInventoryItems.Length) {
            currentInventoryItems[itemIndex].gameObject.SetActive(toggle);
            itemIndex ++;
        }
    }

    private void BuildCurrentItemButtons() {
        if(lastInventoryListChangeVersion == inventoryService.CurrentInventoryListChangeVersion) {
            return;
        }
        lastInventoryListChangeVersion = inventoryService.CurrentInventoryListChangeVersion;
        ClearCurrentItemButtons();
        var index = 0;
        foreach(ActiveItemIndex activeItem in inventoryService.ActiveInventoryList) {  
            currentInventoryItems[index] = CreateItemButtonFromIndex(activeItem, index);
            index++;
        }
        finalPage = (currentInventoryItems.Length - 1) / 10;
    }

    private void ClearCurrentItemButtons() {
        if(currentInventoryItems != null) {
            foreach(ItemButtonController itemButton in currentInventoryItems) {
                GameObject.Destroy(itemButton.gameObject);
            }
        }
        currentInventoryItems = new ItemButtonController[inventoryService.ActiveInventoryList.Length];
    }

    private ItemButtonController CreateItemButtonFromIndex(ActiveItemIndex activeItem, int positionIndex) {
        var itemModel = libraryService.GetByNameAndVersion(activeItem.ItemName, activeItem.ItemVersion);
        var itemButtonGameObject = GameObject.Instantiate(itemButtonPrefab) as GameObject;
        itemButtonGameObject.transform.SetParent(itemButtonsGroup);
        itemButtonGameObject.transform.localPosition = 
            new Vector2(itemButtonDefaultX + (itemButtonSpacing * (positionIndex%itemButtonPageSize)), itemButtonDefaultY); 
        itemButtonGameObject.transform.localScale = new Vector3(1, 1, 1);
        itemButtonGameObject.SetActive(false);
        var itemButton = itemButtonGameObject.GetComponent<ItemButtonController>();
        itemButton.SetItemModel(itemModel);
        itemButton.SetIndex(positionIndex);
        return itemButton;  
    }

    private void InitializeItemButtons() {
        currentItemPage = 0;
        SelectItem(0, true);
        HideItemButtons();
        ToggleItemButtonsByPage(true);
    }

    private void DeactivateInventoryScreen() {
        HideItemButtons();
        inventoryOverlay.SetActive(false);
        inventoryScreen.SetActive(false);
        profileScreen.SetActive(false);
        inventoryCloseButton.SetActive(false);
        presentButton.SetActive(false);
        itemSelectedController.gameObject.SetActive(false);
    }
}
