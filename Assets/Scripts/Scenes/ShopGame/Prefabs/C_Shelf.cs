using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using MEC;
using Mosframe;
using UnityEngine.EventSystems;

public class C_Shelf : UIBehaviour, IDynamicScrollViewItem
{
    [SerializeField] List<C_Item> items = null;

    int dataIndex = -1;

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
        for (int i = 0; i < shelf.data.Count; i++)
        {
            Timing.RunCoroutine(items[i]._Set(shelf.data[i]));
            items[i].gameObject.SetActive(true);
        }

        for (int i = shelf.data.Count; i < items.Count; i++)
        {
            items[i].gameObject.SetActive(false);
        }
    }
}
