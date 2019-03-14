using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("트랩발동");
        TrapOn();
        Destroy(this.gameObject);
    }

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public float radius = 2f;

    private void TrapOn()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, radius, targetMask);
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].GetComponent<Enemy>().IsStop();
        }
    }
}