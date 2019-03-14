using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public void Use()
    {
        this.StartCoroutine(OnOff());
    }

    private IEnumerator OnOff()
    {
        //if (gameObject.activeSelf != true)
        //{
        //    this.gameObject.SetActive(true);
        //}

        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);

        yield return null;
    }
}