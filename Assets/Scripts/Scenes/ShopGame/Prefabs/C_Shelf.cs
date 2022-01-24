using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using MEC;
using Mosframe;
using UnityEngine.EventSystems;

public class C_Shelf : UIBehaviour, IDynamicScrollViewItem
{
    [SerializeField] private C_Item prbItem;
    [SerializeField] private Transform content;

    private List<C_Item> items = new List<C_Item>();

    private int dataIndex = -1;

    public void onUpdateItem(int index)
    {
        if (C_Shelfs.instance.data.Count > index)
        {
            this.dataIndex = index;
            this.updateItem();
        }
    }

    private void updateItem()
    {
        if (this.dataIndex == -1) return;

        M_Shelf shelf = C_Shelfs.instance.data[this.dataIndex];
        
        // Clear old
        for (int i = 0; i < items.Count; i++)
        {
            PoolManager.S.Despawn(items[i]);
        }
        items.Clear();

        // Spawn new
        for (int i = 0; i < shelf.data.Count; i++)
        {
            C_Item item = PoolManager.S.Spawn(prbItem, content);
            Timing.RunCoroutine(item._Set(shelf.data[i]));

            items.Add(item);
        }
    }
}
