using MEC;
using Mosframe;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class C_Shelfs : MonoBehaviour
{
    public static C_Shelfs instance;

    public List<M_Shelf> data = new List<M_Shelf>();

    DynamicScrollView scrollView;

    private void Awake()
    {
        scrollView = GetComponent<DynamicScrollView>();
        if (instance == null) instance = this;
    }

    public void LoadData()
    {
        List<M_Item> m_shelfs = ResourceManager.S.LoadItemsData();
        data.Clear();

        int sizeShelf = 3;
        int rs = m_shelfs.Count / sizeShelf;

        for (int i = 0; i < rs; i++)
        {
            M_Shelf m_shelf = new M_Shelf();
            for (int j = i * sizeShelf; j < (i + 1) * sizeShelf; j++)
            {
                m_shelf.data.Add(m_shelfs[j]);
            }
            data.Add(m_shelf);
        }

        if (rs * sizeShelf < m_shelfs.Count)
        {
            M_Shelf m_shelf = new M_Shelf();
            for (int j = rs * sizeShelf; j < m_shelfs.Count; j++)
            {
                m_shelf.data.Add(m_shelfs[j]);
            }
            data.Add(m_shelf);
        }

        scrollView.totalItemCount = data.Count;

        scrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
    }
}
