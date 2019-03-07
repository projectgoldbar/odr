using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset = Vector3.zero;

    // Update is called once per frame
    private void LateUpdate()
    {
        offset = transform.position - target.position;
        transform.position = new Vector3(
            target.position.x,
            target.position.y + offset.y,
            target.position.z);
    }
}