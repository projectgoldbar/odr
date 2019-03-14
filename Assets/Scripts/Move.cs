using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    private enum RotState { 전진, 오른쪽, 왼쪽 };

    [SerializeField]
    private RotState rotState = RotState.전진;

    public float runSpeed = 2.0f;
    public float rotSpeed = 3.0f;
    public float damp = 20.0f;
    public Rigidbody rid;

    private Vector2 touchPos = Vector2.zero;

    private void Start()
    {
        StartCoroutine(MoveRot());
    }

    private void Update()
    {
#if UNITY_EDITOR

        touchPos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            if (touchPos.x <= Screen.width * 0.5)
            {
                rotState = RotState.왼쪽;
            }
            else
            {
                rotState = RotState.오른쪽;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            rotState = RotState.전진;
        }

#else
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                 if (touchPos.x <= Screen.width * 0.5)
                {
                   rotState = RotState.왼쪽;
                }
                else
                {
                    rotState = RotState.오른쪽;
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                rotState = RotState.전진;
            }
        }

#endif
    }

    private void FixedUpdate()
    {
        rid.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * runSpeed);
    }

    private IEnumerator MoveRot()
    {
        for (; ; )
        {
            if (rotState == RotState.왼쪽)
            {
                transform.rotation *= Quaternion.Euler(Vector3.up * Time.deltaTime * -rotSpeed * damp);
            }
            else if (rotState == RotState.오른쪽)
            {
                transform.rotation *= Quaternion.Euler(Vector3.up * Time.deltaTime * rotSpeed * damp);
            }
            yield return null;
        }
    }
}