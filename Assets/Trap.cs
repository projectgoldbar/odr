using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour
{
    private void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("트랩발동");
        TrapOn();

        Invoke("Destroy", 0.5f);
        GetComponent<Collider>().enabled = false;
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public float radius = 2f;

    private void TrapOn()
    {
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        Collider[] targets = Physics.OverlapSphere(transform.position, radius, targetMask);
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].GetComponent<Enemy>().IsStop();
        }
    }
}