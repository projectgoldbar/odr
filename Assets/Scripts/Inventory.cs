using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[DefaultExecutionOrder(-500)]
public class Inventory : MonoBehaviour
{
    public Image itemImage;
    public List<Item> inven = new List<Item>();

    //public Queue<Item> inventory = new Queue<Item>();
    public event Action ItemChanged = () => { };

    public void use()
    {
        if (inven[0] == null)
        {
            Debug.Log("아이템다썻음");
            itemImage.sprite = null;
            return;
        }
        else
        {
            inven[0].use();
            itemImage.sprite = inven[1].itemImg;
            inven.RemoveAt(0);
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