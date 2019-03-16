using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-500)]
public class Inventory : MonoBehaviour
{
    public List<Image> itemimglist = new List<Image>();
    public List<Item> inven = new List<Item>();

    //public Queue<Item> inventory = new Queue<Item>();

    public event Action ItemChanged = () => { };

    public void ItemImgChange()
    {
        var x = itemimglist.Count - (itemimglist.Count - inven.Count);

        for (int i = 0; i < inven.Count; i++)
        {
            itemimglist[i].sprite = inven[i].itemImg;
        }
        for (int i = x; i < itemimglist.Count; i++)
        {
            itemimglist[i].sprite = null;
        }

        //for (int i = 0; i < itemimglist.Count; i++)
        //{
        //    if (i >= x)
        //    {
        //        itemimglist[i].sprite = null;
        //    }
        //    else
        //    {
        //        itemimglist[i].sprite = inven[i].itemImg;
        //    }
        //}
    }

    public void use()
    {
        if (inven.Count >= 1)
        {
            inven[0].use();
            //Destroy(inven[0].gameObject);
            inven.RemoveAt(0);
            //if (inven.Count == 0)
            //{
            //    itemImage.sprite = null;
            //}
            //else
            //itemImage.sprite = inven[0].itemImg;
            //itemImage2.sprite = inven[1].itemImg;
            ItemImgChange();
            //itemImage3.sprite = inven[2].itemImg;
        }
        else
        {
            Debug.Log("아이템다썻음");
            //itemImage.sprite = null;
            //Destroy(inven[0].gameObject);
            //inven.RemoveAt(0);
        }
        ItemImgChange();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            use();
        }
    }
}