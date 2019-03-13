using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetete : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Item>().use();
        }
    }
}