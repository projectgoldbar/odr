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
    public ParticleSystem deathFx;

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
        if (color == lightColor || hp <= 1)
        {
            ItemGoldDataBase.instance.gold += gold;
            speed = 0;
            deathFx.Play();
            Invoke("DestroyGo", 1f);
        }
        else
        {
            this.gameObject.transform.localScale *= 2;
            hp--;

            speed += 1f;
        }
    }

    private void DestroyGo()
    {
        Destroy(this.gameObject.GetComponent<Enemy>().stateImage);
        Destroy(this.gameObject);
    }
}