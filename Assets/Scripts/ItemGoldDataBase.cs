using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGoldDataBase : MonoBehaviour
{
    public static ItemGoldDataBase instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public List<GameObject> AllitemList = new List<GameObject>();
    public List<GameObject> SpwanItemDataList = new List<GameObject>();
    public int gold = 50;
}