using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Inventory>().inventory.Enqueue(this);
        //other.gameObject.GetComponent<Inventory>().inven.Add(this);
        this.gameObject.SetActive(false);
    }

    public void use()
    {
        Debug.Log("아이템사용");
    }
}