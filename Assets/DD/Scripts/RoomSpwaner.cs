using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpwaner : MonoBehaviour
{
    public enum OpeningDirention
    { bottom = 1, top, left, right }

    public OpeningDirention openingDirention = OpeningDirention.top;

    private RoomTemplates templates;

    private int randomNum;

    private bool spawned = false;

    private void Awake()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    private void Start()
    {
        Invoke("Spawn", 1f);
    }

    private void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirention == OpeningDirention.bottom)
            {
                randomNum = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[randomNum], transform.position, templates.bottomRooms[randomNum].transform.rotation);
            }
            else if (openingDirention == OpeningDirention.top)
            {
                randomNum = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[randomNum], transform.position, templates.topRooms[randomNum].transform.rotation);
            }
            else if (openingDirention == OpeningDirention.left)
            {
                randomNum = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[randomNum], transform.position, templates.leftRooms[randomNum].transform.rotation);
            }
            else if (openingDirention == OpeningDirention.right)
            {
                randomNum = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[randomNum], transform.position, templates.rightRooms[randomNum].transform.rotation);
            }
            spawned = true;
            //Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpwonPoint") && other.GetComponent<RoomSpwaner>().spawned == true)
        {
            Destroy(gameObject);
        }
    }
}