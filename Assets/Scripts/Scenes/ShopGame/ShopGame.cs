using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGame : MonoBehaviour
{
    public static ShopGame instance = null;

    [SerializeField] C_Shelfs shelfs = null;
    [SerializeField] C_Desc desc = null;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        shelfs.LoadData();
    }

    public void ShowDesc(M_Item item)
    {
        desc.Set(item);
    }
}
