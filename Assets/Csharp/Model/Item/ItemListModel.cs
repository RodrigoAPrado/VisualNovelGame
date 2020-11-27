using System;
using System.Collections.Generic;
using UnityEngine;

namespace Csharp.Model.Item
{
    [SerializableAttribute]
    public class ItemListModel
    {
        [SerializeField]
        public ItemModel[] itemList;    
    }
}