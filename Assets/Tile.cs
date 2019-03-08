using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject itemPreFab;
    public GameObject trapPreFab;
    public int count;

    private List<GameObject> everyList = new List<GameObject>();
    private List<Item> itemList = new List<Item>();
    private List<GameObject> wallList = new List<GameObject>();

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        VectorSet(count);
        ItemTrapSet();
    }

    private List<Vector3> randomVeclist = new List<Vector3>();

    private void VectorSet(int setCount)
    {
        for (int i = 0; i < setCount; i++)
        {
            int x = Random.Range(-49, 49);
            int z = Random.Range(-49, 49);
            var a = new Vector3(x, 0.5f, z);
            if (randomVeclist.Contains(a))
            {
                i--;
                continue;
            }
            else
            {
                randomVeclist.Add(a);
            }
        }
    }

    private void ItemTrapSet()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(itemPreFab, randomVeclist[0], Quaternion.identity);
            randomVeclist.RemoveAt(0);
        }
        for (int i = 0; i < randomVeclist.Count; i++)
        {
            Instantiate(trapPreFab, randomVeclist[i], Quaternion.identity);
        }
    }
}