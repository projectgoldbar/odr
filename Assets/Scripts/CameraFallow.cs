using System;
using System.Collections;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset = Vector3.zero;
    private float damp = 1.5f;

    private Coroutine StopRutine;
    public static Action rotatestop = () => { };

    private void OnEnable()
    {
        Move.touchout += CameraSmoothRotation;
        //Move.touchout += CameraRotation;
    }

    private void OnDisable()
    {
        Move.touchout -= CameraSmoothRotation;
        rotatestop -= CameraRotationStop;
        //Move.touchout -= CameraRotation;
    }

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

    public void CameraSmoothRotation()
    {
        StopRutine = StartCoroutine(smoothRotation());
    }

    public void CameraRotation()
    {
        transform.rotation = target.rotation;
    }

    public void CameraRotationStop()
    {
        StopCoroutine(StopRutine);
    }

    private IEnumerator smoothRotation()
    {
        for (; ; )
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.smoothDeltaTime * damp);

            yield return null;
        }
    }
}