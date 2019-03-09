using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<Inventory>().inventory.Enqueue(this);
        //other.gameObject.GetComponent<Inventory>().inven.Add(this);
        //gameObject.GetComponent<Renderer>().enabled = false;
        //gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.SetActive(false);
    }

    public void use()
    {
        Debug.Log("아이템사용");
    }
}