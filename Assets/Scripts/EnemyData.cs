using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Type { Scissors, Rock, Crepe };

public class EnemyData : MonoBehaviour
{
    public float speed;
    public int hp;
    public int gold;
    public Action SomeThing = () => { };
    public ParticleSystem deathFx;

    public Type type = Type.Scissors;
    private Color color;

    private void Awake()
    {
        color = GetComponentInChildren<SkinnedMeshRenderer>().material.color;
    }

    //public void OnHit(Color lightColor)
    //{
    //    Invoke("OndirectDamage", 1f);
    //}

    public void OndirectDamage(Color lightColor, Type itemType)
    {
        switch (this.type)
        {
            case Type.Scissors:
                if (itemType == this.type)
                {
                    return;
                }
                else if (itemType == Type.Rock)
                {
                    DestroyGo();
                }
                else if (itemType == Type.Crepe)
                {
                    this.gameObject.transform.localScale *= 2;
                }
                break;

            case Type.Rock:
                if (itemType == this.type)
                {
                    return;
                }
                else if (itemType == Type.Crepe)
                {
                    DestroyGo();
                }
                else if (itemType == Type.Scissors)
                {
                    this.gameObject.transform.localScale *= 2;
                }
                break;

            case Type.Crepe:
                if (itemType == this.type)
                {
                    return;
                }
                else if (itemType == Type.Scissors)
                {
                    DestroyGo();
                }
                else if (itemType == Type.Rock)
                {
                    this.gameObject.transform.localScale *= 2;
                }
                break;

            default:
                break;
        }
        //if (color == lightColor || hp <= 1)
        //{
        //    ItemGoldDataBase.instance.gold += gold;
        //    speed = 0;
        //    deathFx.Play();
        //    Invoke("DestroyGo", 1f);
        //}
        //else
        //{
        //    this.gameObject.transform.localScale *= 2;
        //    hp--;

        //    speed += 1f;
        //}
    }

    private void DestroyGo()
    {
        Destroy(this.gameObject.GetComponent<Enemy>().stateImage);
        Destroy(this.gameObject);
    }
}