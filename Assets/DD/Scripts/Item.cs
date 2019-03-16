using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Item : MonoBehaviour
{
    public Sprite itemImg;
    public int price = 1;
    public Type type = Type.Scissors;

    protected Transform playervecter;
    protected Transform playerLight;
    //public Transform playervecter;

    protected void OnTriggerEnter(Collider other)
    {
        var x = other.gameObject.GetComponent<Inventory>();

        if (x != null)
        {
            playervecter = x.transform;
            playerLight = other.transform.GetChild(0);
            //x.ItemChanged = () => { x.itemImage.sprite = itemImg; };
            if (x.inven.Count > 2)
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

    public LayerMask TargetMask;
    public LayerMask ObstacleMask;

    protected Color lightcolor = Color.white;

    protected virtual void ColorSet()
    {
        lightcolor = Color.white;
    }

    public virtual void use()
    {
        Debug.Log("아이템사용");
        playerLight.gameObject.SetActive(true);
        playerLight.GetComponent<Light>().color = lightcolor;

        playerLight.GetComponent<FlashLight>().Use();
        var a = FindVisibleTargets(playervecter, 30f, 60f, TargetMask, ObstacleMask);
        if (a != null)
        {
            for (int i = 0; i < a.Count; i++)
            {
                //a[i].GetComponentInChildren<SkinnedMeshRenderer>().material.color = lightcolor;
                a[i].GetComponentInChildren<EnemyData>().OndirectDamage(lightcolor, type);
            }
        }
        //playerLight.gameObject.SetActive(false);

        Destroy(this.gameObject);
    }

    public List<Transform> FindVisibleTargets(Transform _transform, float ViewDistance, float ViewAngle, LayerMask TargetMask, LayerMask ObstacleMask)
    {
        //시야거리 내에 존재하는 모든 컬라이더 받아오기
        Collider[] targets = Physics.OverlapSphere(_transform.position, ViewDistance, TargetMask);
        List<Transform> returnValue = new List<Transform>();
        for (int i = 0; i < targets.Length; i++)
        {
            Transform target = targets[i].transform;

            // 타겟까지의 단위벡터
            Vector3 dirToTarget = (target.position - _transform.position).normalized;

            //_transform.forward와 dirToTarget은 모두 단위벡터이므로 내적값은 두 벡터가 이루는 각의 Cos값과 같다.
            //내적값이 시야각/2의 Cos값보다 크면 시야에 들어온 것이다.
            if (Vector3.Dot(_transform.forward, dirToTarget) > Mathf.Cos((ViewAngle / 2) * Mathf.Deg2Rad))
            //if (Vector3.Angle(_transform.forward, dirToTarget) < ViewAngle/2)
            {
                float distToTarget = Vector3.Distance(_transform.position, target.position);

                if (!Physics.Raycast(_transform.position, dirToTarget, distToTarget, ObstacleMask))
                {
                    returnValue.Add(target);
                }
            }
        }
        return returnValue;
    }
}