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

    public Material material;

    //public void OnHit(Color lightColor)
    //{
    //    Invoke("OndirectDamage", 1f);
    //}

    public void OndirectDamage(Color lightColor)
    {
        if (material.color == lightColor)
        {
            ItemGoldDataBase.instance.gold += gold;
            Destroy(this.gameObject);
        }
        else
        {
            material.color = lightColor;
            speed += 1f;
        }
    }
}