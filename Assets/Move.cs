using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Coroutine left;
    private Coroutine right;

    //코루틴 변수 = 코루틴 실행

    //스탑코루틴(코루틴 변수)

    private void Awake()
    {
        Debug.Log("게임시작");
        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        for (; ; )
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }
    }

    public void leftbutton()
    {
        Debug.Log("왼쪽 회전");
        LeftCuc();
    }

    public void rightbutton()
    {
        Debug.Log("오른쪽 회전");
        RightCuc();
    }

    public void leftbuttonUp()
    {
        StopCoroutine(left);
    }

    public void rightbuttonUp()
    {
        StopCoroutine(right);
    }

    private void LeftCuc()
    {
        left = StartCoroutine(LeftRotCorutine());
    }

    private void RightCuc()
    {
        right = StartCoroutine(RightRotCorutine());
    }

    private IEnumerator LeftRotCorutine()
    {
        for (; ; )
        {
            transform.rotation *= Quaternion.Euler(Vector3.up * -1.0f);
            yield return null;
        }
    }

    private IEnumerator RightRotCorutine()
    {
        for (; ; )
        {
            transform.rotation *= Quaternion.Euler(Vector3.up * 1.0f);
            yield return null;
        }
    }
}