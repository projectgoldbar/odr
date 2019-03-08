using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// 좌측 우측 터치시 회전하는 방식으로 바꾸기.
/// </summary>
public class Move : MonoBehaviour
{
    public float runSpeed = 2.0f;
    public float rotSpeed = 3.0f;
    public Rigidbody rid;

    private Coroutine left;
    private Coroutine right;
    private Action touchout = () => { };
    private Vector2 touchPos = Vector2.zero;

    private void Awake()
    {
        StartCoroutine(Run());

        touchout += RightTouchUp;
        touchout += LeftTouchUp;
    }

    private IEnumerator Run()
    {
        for (; ; )
        {
            rid.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * runSpeed);

            yield return null;
        }
    }

    private void Update()
    {
#if UNITY_EDITOR

        touchPos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            if (touchPos.x <= Screen.width * 0.5)
                LeftTouchDown();
            else
                RightTouchDown();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touchout?.Invoke();
        }

#else
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (touchPos.x <= Screen.width * 0.5)
                    LeftTouchDown();
                else
                    RightTouchDown();
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                touchout?.Invoke();
            }
        }

#endif
    }

    public void LeftTouchDown() => left = StartCoroutine(LeftRotCorutine());

    public void RightTouchDown() => right = StartCoroutine(RightRotCorutine());

    public void LeftTouchUp() => StopCoroutine(left);

    public void RightTouchUp() => StopCoroutine(right);

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