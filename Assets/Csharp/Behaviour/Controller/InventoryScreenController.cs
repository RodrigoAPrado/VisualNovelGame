using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Csharp.Service;
using Csharp.Model.Item;

public class InventoryScreenController : MonoBehaviour
{
    public GameObject itemButtonPrefab;
    public Transform itemButtonsGroup;
    public GameObject inventoryOverlay;
    public GameObject inventoryScreen;
    public GameObject profileScreen;
    public GameObject inventoryCloseButton;
    private InventoryService inventoryService;
    private ItemLibraryService libraryService;
    private int lastInventoryListChangeVersion;
    private GameObject[] currentInventoryItems;
    private int itemButtonSpacing = 164;
    private int itemButtonDefaultX = -740;
    private int itemButtonDefaultY = -118;
    private int itemButtonPageSize = 10;
    private int currentItemPage = 0;
    private int finalPage = 0;

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
        InitializeItemButtons();
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
            foreach(GameObject gameObject in currentInventoryItems) {
                GameObject.Destroy(gameObject);
            }
        }
        currentInventoryItems = new GameObject[inventoryService.ActiveInventoryList.Length];
    }

    private GameObject CreateItemButtonFromIndex(ActiveItemIndex activeItem, int positionIndex) {
        var itemModel = libraryService.GetByNameAndVersion(activeItem.ItemName, activeItem.ItemVersion);
        var itemButton = GameObject.Instantiate(itemButtonPrefab) as GameObject;
        itemButton.transform.SetParent(itemButtonsGroup);
        itemButton.transform.localPosition = 
            new Vector2(itemButtonDefaultX + (itemButtonSpacing * (positionIndex%itemButtonPageSize)), itemButtonDefaultY); 
        itemButton.transform.localScale = new Vector3(1, 1, 1);
        itemButton.GetComponent<ItemButtonController>().SetItemModel(itemModel);
        itemButton.SetActive(false);
        return itemButton;  
    }

    public void InitializeItemButtons() {
        currentItemPage = 0;
        HideItemButtons();
        ToggleItemButtonsByPage(true);
    }

    public void HideItemButtons() {
        if(currentInventoryItems == null) {
            return;
        }
        foreach(GameObject itemButton in currentInventoryItems) {
            if(itemButton != null) {
                itemButton.SetActive(false);
            }
        }
    }

    public void ToggleItemButtonsByPage(bool toggle){
        int itemIndex = currentItemPage * itemButtonPageSize;
        int finalItemIndex = itemIndex + itemButtonPageSize - 1;
        while(itemIndex <= finalItemIndex && itemIndex < currentInventoryItems.Length) {
            currentInventoryItems[itemIndex].SetActive(toggle);
            itemIndex ++;
        }
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

    private void DeactivateInventoryScreen() {
        HideItemButtons();
        inventoryOverlay.SetActive(false);
        inventoryScreen.SetActive(false);
        profileScreen.SetActive(false);
        inventoryCloseButton.SetActive(false);
    }
}
