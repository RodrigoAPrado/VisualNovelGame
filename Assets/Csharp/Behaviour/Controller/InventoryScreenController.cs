using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScreenController : MonoBehaviour
{

    public GameObject inventoryOverlay;
    public GameObject inventoryScreen;
    public GameObject profileScreen;
    public GameObject inventoryCloseButton;

    void Awake() {
        DeactivateInventoryScreen();
    }

    public void ShowItemScreen() {
        inventoryOverlay.SetActive(true);    
        inventoryScreen.SetActive(true);
        inventoryCloseButton.SetActive(true);
    }

    public void HideItemScreen() {
        DeactivateInventoryScreen();
    }

    private void DeactivateInventoryScreen() {
        inventoryOverlay.SetActive(false);
        inventoryScreen.SetActive(false);
        profileScreen.SetActive(false);
        inventoryCloseButton.SetActive(false);
    }
}
