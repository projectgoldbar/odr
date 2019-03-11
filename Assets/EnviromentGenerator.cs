using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentGenerator : MonoBehaviour
{
    public GameObject itemPreFab;
    public GameObject trapPreFab;
    public int count;

    public List<GameObject> enviroPreFab = new List<GameObject>();

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
        EnviromentSet();
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
        for (int i = 0; i < 20; i++)
        {
            Instantiate(itemPreFab, randomVeclist[0], Quaternion.identity);
            randomVeclist.RemoveAt(0);
        }
        for (int i = 0; i < 20; i++)
        {
            Instantiate(trapPreFab, randomVeclist[0], Quaternion.identity);
            randomVeclist.RemoveAt(0);
        }
    }

    private void EnviromentSet()
    {
        for (int i = 0; i < 150; i++)
        {
            var x = Random.Range(0, enviroPreFab.Count);
            Instantiate(enviroPreFab[x], randomVeclist[0], Quaternion.identity);
            randomVeclist.RemoveAt(0);
        }
    }
}