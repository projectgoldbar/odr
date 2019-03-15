using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyData : MonoBehaviour
{
    public float speed;
    public int hp;
    public int gold;
    public Action SomeThing = () => { };

    private Color color;

    private void Awake()
    {
        color = GetComponentInChildren<SkinnedMeshRenderer>().material.color;
    }

    //public void OnHit(Color lightColor)
    //{
    //    Invoke("OndirectDamage", 1f);
    //}

    public void OndirectDamage(Color lightColor)
    {
        if (color == lightColor)
        {
            ItemGoldDataBase.instance.gold += gold;
            Destroy(this.gameObject.GetComponent<Enemy>().stateImage);
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.transform.localScale *= 2;
            speed += 1f;
        }
    }
}