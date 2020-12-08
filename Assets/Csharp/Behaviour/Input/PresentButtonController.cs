using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Csharp.Model.Item;

public class PresentButtonController : MonoBehaviour
{
    public InventoryScreenController inventoryScreenController;
    public CrossExaminationController crossExaminationController;
    public GameObject presentButton;

    void Awake() {
        presentButton.SetActive(false);
        crossExaminationController.CrossExamStart += ActivatePresentButton;
    }

    public void OnPresent() {
        inventoryScreenController.HideItemScreen();
        var itemModel = inventoryScreenController.ItemSelected;
        var choice = itemModel.storyVariableName.Replace("_", "-");
        crossExaminationController.SelectOption("present:" + choice);
        presentButton.SetActive(false);
    }

    private void ActivatePresentButton() {
        presentButton.SetActive(true);
    }
}
