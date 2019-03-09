using System.Collections;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset = Vector3.zero;
    private float damp = 4.0f;

    // Update is called once per frame
    private void LateUpdate()
    {
        offset = transform.position - target.position;

        var Move_vec = new Vector3(
            target.position.x,
            target.position.y + offset.y,
            target.position.z);

        transform.position = Move_vec;
        //Vector3.Lerp(transform.position, Move_vec, Time.deltaTime * damp);
    }

    private IEnumerator rot()
    {
        for (; ; )
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, damp);

            yield return null;
        }
    }
}