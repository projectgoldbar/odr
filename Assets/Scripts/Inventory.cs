using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-500)]
public class Inventory : MonoBehaviour
{
    public Image itemImage = null;
    public List<Item> inven = new List<Item>();

    //public Queue<Item> inventory = new Queue<Item>();

    public event Action ItemChanged = () => { };

    public void use()
    {
        if (inven.Count >= 1)
        {
            inven[0].use();
            //Destroy(inven[0].gameObject);
            inven.RemoveAt(0);
            if (inven.Count == 0)
            {
                itemImage.sprite = null;
            }
            else
                itemImage.sprite = inven[0].itemImg;
        }
        else
        {
            Debug.Log("아이템다썻음");
            itemImage.sprite = null;
            //Destroy(inven[0].gameObject);
            //inven.RemoveAt(0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            use();
        }
    }
}