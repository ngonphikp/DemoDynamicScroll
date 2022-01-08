using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Desc : MonoBehaviour
{
    [SerializeField] Image imgItem = null;
    [SerializeField] Text txtName = null;

    [SerializeField] Text txtDesc = null;

    public void Set(M_Item item)
    {
        imgItem.sprite = ResourceManager.S.LoadSprite("ShopItem", item.icon);
        txtName.text = item.title;

        txtDesc.text = item.desc;
    }
}
