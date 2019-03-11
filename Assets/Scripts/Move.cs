using System;
using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static Action touchout = () => { };

    public float runSpeed = 2.0f;
    public float rotSpeed = 3.0f;
    public Rigidbody rid;

    private Coroutine left;
    private Coroutine right;
    private Coroutine Rot;
    private Vector2 touchPos = Vector2.zero;

    private CameraFallow cam;

    private void OnEnable()
    {
        touchout += RotStop;
    }

    private void OnDisable()
    {
        touchout -= RotStop;
    }

    private void Start()
    {
        cam = FindObjectOfType<CameraFallow>();
        StartCoroutine(Run());
    }

    private void Update()
    {
#if UNITY_EDITOR

        touchPos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            if (touchPos.x <= Screen.width * 0.5)
            {
                LeftTouchDown();
                cam.rotatestop?.Invoke();
            }
            else
            {
                RightTouchDown();
                cam.rotatestop?.Invoke();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touchout?.Invoke();
            cam.rotatestop += cam.CameraRotationStop;
        }

#else
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (touchPos.x <= Screen.width * 0.5)
                {
                    LeftTouchDown();

                    cam.rotatestop?.Invoke();
                }
                else
                {
                    RightTouchDown();
                    cam.rotatestop?.Invoke();
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                touchout?.Invoke();
                cam.rotatestop += cam.CameraRotationStop;
            }
        }

#endif
    }

    public void LeftTouchDown() => Rot = StartCoroutine(LeftRotCorutine());

    public void RightTouchDown() => Rot = StartCoroutine(RightRotCorutine());

    public void RotStop() => StopCoroutine(Rot);

    private IEnumerator Run()
    {
        for (; ; )
        {
            rid.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * runSpeed);
            yield return null;
        }
    }

    private IEnumerator LeftRotCorutine()
    {
        for (; ; )
        {
            transform.rotation *= Quaternion.Euler(Vector3.up * -rotSpeed);

            yield return new WaitForSeconds(0.02f);
            yield return null;
        }
    }

    private IEnumerator RightRotCorutine()
    {
        for (; ; )
        {
            transform.rotation *= Quaternion.Euler(Vector3.up * rotSpeed);

            yield return new WaitForSeconds(0.02f);
            yield return null;
        }
    }
}