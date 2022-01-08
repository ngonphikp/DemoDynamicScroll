using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Item
{
    public int id = 1;
    public string icon = "001";
    public string title = "Title";
    public string desc = "Desc";
    public int price = 1000;

    public M_Item()
    {

    }

    public void Update()
    {
        M_Item rs = ResourceManager.S.LoadItemData(id);

        icon = rs.icon;
        title = rs.title;
        desc = rs.desc;
        price = rs.price;
    }
}

public class M_Shelf
{
    public List<M_Item> data = new List<M_Item>();
}
