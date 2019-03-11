using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Sprite itemImg;

    private Transform playervecter;

    private void OnCollisionEnter(Collision other)
    {
        var x = other.gameObject.GetComponent<Inventory>();

        if (x != null)
        {
            playervecter = x.transform;
            //x.ItemChanged = () => { x.itemImage.sprite = itemImg; };
            if (x.inven.Count > 3)
            {
                x.inven[0] = this;
                //Instantiate(itemImg);
                x.itemImage.sprite = itemImg;
                this.gameObject.SetActive(false);
            }
            else
            {
                x.inven.Add(this);

                //Instantiate(itemImg);
                x.itemImage.sprite = itemImg;
            }
            this.gameObject.SetActive(false);
        }
        else
            Destroy(this.gameObject);

        //other.gameObject.GetComponent<Inventory>().inventory.Enqueue(this);
        //gameObject.GetComponent<Renderer>().enabled = false;
        //gameObject.GetComponent<Renderer>().enabled = false;
    }

    public void use()
    {
        Debug.Log("아이템사용");
        var a = Physics.RaycastAll(playervecter.position, playervecter.forward, 3f, 1 << 10);
        foreach (var item in a)
        {
            Destroy(item.transform.gameObject);
        }
        Destroy(this.gameObject);
    }
}