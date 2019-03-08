using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("트랩발동");
        Destroy(this.gameObject);
    }
}