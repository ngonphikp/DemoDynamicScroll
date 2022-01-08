using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Item : MonoBehaviour
{
    [SerializeField] Image imgItem = null;
    [SerializeField] Text txtName = null;
    [SerializeField] Text txtPrice = null;

    M_Item item = null;

    public IEnumerator<float> _Set(M_Item item)
    {
        if (item != null && ((this.item != null && item.id != this.item.id) || this.item == null))
        {
            this.item = item;

            imgItem.sprite = ResourceManager.S.LoadSprite("ShopItem", item.icon);
            txtName.text = item.title;
            txtPrice.text = item.price + "";
        }

        yield break;
    }

    public void OnClick()
    {
        ShopGame.instance.ShowDesc(item);
    }
}
