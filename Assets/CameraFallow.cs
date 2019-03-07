using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset = Vector3.zero;
    private float damp = 1.0f;

    // Update is called once per frame
    private void LateUpdate()
    {
        offset = transform.position - target.position;

        var Move_vec = new Vector3(
            target.position.x,
            target.position.y + offset.y,
            target.position.z);

        transform.position =
            Vector3.Lerp(transform.position, Move_vec, Time.deltaTime * damp);

        transform.rotation =
            Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * damp);
    }
}