using System;
using System.Collections;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset = Vector3.zero;
    public float damp = 5f;

    private Coroutine StopRutine;
    public Action rotatestop = () => { };

    /// <summary>
    /// 인스펙터에서 확인용 Public
    /// </summary>
    public bool changeCameraRotion;

    public bool ChangeCameraRotation
    {
        get => changeCameraRotion;
        set
        {
            changeCameraRotion = value;
            if (!changeCameraRotion)
            {
                Move.touchout += CameraSmoothRotation;
                Move.touchout -= CameraRotation;
                rotatestop += CameraRotationStop;
            }
            else
            {
                Move.touchout -= CameraSmoothRotation;
                Move.touchout += CameraRotation;
                rotatestop -= CameraRotationStop;
            }
        }
    }

    private void OnEnable()
    {
        Move.touchout += CameraSmoothRotation;

        offset = transform.position - target.position;
    }

    private void OnDisable()
    {
        // Move.touchout -= CameraSmoothRotation;
        //Move.touchout -= CameraRotation;
        rotatestop -= CameraRotationStop;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeCameraRotation = !ChangeCameraRotation;

        var Move_vec = new Vector3(
            target.localPosition.x,
            target.localPosition.y + offset.y,
            target.localPosition.z);

        transform.position = Move_vec;
    }

    public void CameraSmoothRotation()
    {
        StopRutine = StartCoroutine(smoothRotation());
    }

    private Vector3 a = new Vector3();

    public void CameraRotation()
    {
        StopRutine = StartCoroutine(NotRotation());
    }

    public void CameraRotationStop()
    {
        StopCoroutine(StopRutine);
    }

    private IEnumerator smoothRotation()
    {
        for (; ; )
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, Time.deltaTime * damp);

            yield return null;
        }
    }

    private IEnumerator NotRotation()
    {
        Debug.Log("Not CameraRotate");
        yield return null;
    }
}