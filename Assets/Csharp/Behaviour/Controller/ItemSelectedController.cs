using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Csharp.Model.Item;

public class ItemSelectedController : MonoBehaviour
{
    public Image iconSprite;
    public TMP_Text itemName;
    public TMP_Text itemDescription;

    public void SetSelectedItem(ItemModel itemModel) {
        iconSprite.sprite = itemModel.BigIcon;
        itemName.text = itemModel.writtenName;
        itemDescription.text = itemModel.itemDescription;
    }
}
