using Sfs2X.Entities.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager S;

    private Dictionary<string, Sprite> dicSP = new Dictionary<string, Sprite>();
    private Dictionary<string, AudioClip> dicClip = new Dictionary<string, AudioClip>();

    private Dictionary<int, M_Item> dicIT = new Dictionary<int, M_Item>();

    [SerializeField] private List<SpriteAtlas> Atlas = new List<SpriteAtlas>();
    private Dictionary<string, SpriteAtlas> dicAtlas = new Dictionary<string, SpriteAtlas>();

#if UNITY_EDITOR
    private static List<SpriteAtlas> sAtlas = new List<SpriteAtlas>();
    private void OnValidate()
    {
        sAtlas.Clear();
        foreach (var item in Atlas)
        {
            sAtlas.Add(item);
        }
    }
#endif

    private void Awake()
    {
        if (!S) S = this;

        foreach (var item in Atlas)
        {
            dicAtlas.Add(item.name, item);
        }

        LoadConfigs();
    }

    private void Start()
    {

    }

    private void LoadConfigs()
    {
        dicIT.Clear();
        TextAsset file = Resources.Load<TextAsset>("Configs/ShopItems");
        ISFSObject obj = SFSObject.NewFromJsonData(file.ToString());
        ISFSArray lst = obj.GetSFSArray("items");
        for (int i = 0; i < lst.Count; i++)
        {
            ISFSObject item = lst.GetSFSObject(i);
            int key = item.GetInt("id");
            if (!dicIT.ContainsKey(key))
            {
                dicIT.Add(key, new M_Item()
                {
                    id = key,
                    icon = item.GetUtfString("icon"),
                    title = item.GetUtfString("title"),
                    desc = item.GetUtfString("desc"),
                    price = item.GetInt("price")
                });
            }
        }
    }

    public Sprite LoadSprite(string path, bool save = true)
    {
        return Load("Textures/" + path, dicSP, save);
    }

    public Sprite LoadSprite(string atlas, string name)
    {
        string path = atlas + "/" + name;

        if (!dicSP.ContainsKey(path))
        {
            Sprite t = dicAtlas[atlas].GetSprite(name);

            if (t) dicSP.Add(path, t);
            else Debug.LogError("Resource Null: " + path);
        }

        if (dicSP.ContainsKey(path)) return dicSP[path];
        return default;
    }

    public AudioClip LoadClip(string path, bool save = true)
    {
        return Load("Audios/" + path, dicClip, save);
    }

    public M_Item LoadItemData(int id)
    {
        return dicIT[id];
    }

    public List<M_Item> LoadItemsData()
    {
        return dicIT.Values.ToList();
    }

    private T Load<T>(string path, Dictionary<string, T> dic, bool save = true) where T : Object
    {
        if (save)
        {
            if (!dic.ContainsKey(path))
            {
                T t = Resources.Load<T>(path);

                if (t) dic.Add(path, t);
                else Debug.LogError("Resource Null: " + path);
            }

            if (dic.ContainsKey(path)) return dic[path];
            return default;
        }
        else
        {
            return Resources.Load<T>(path);
        }
    }
}
