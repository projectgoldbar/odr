using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inven = new List<Item>();
    public Queue<Item> inventory = new Queue<Item>();

    public void use()
    {
        if (inventory.Count == 0)
        {
            Debug.Log("아이템다썻음");
            return;
        }
        var a = inventory.Dequeue();
        a.use();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            use();
        }
    }
}