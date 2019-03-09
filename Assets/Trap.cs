using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("트랩발동");
        Destroy(this.gameObject);
    }
}