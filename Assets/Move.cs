using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Coroutine left;
    private Coroutine right;

    public float runSpeed = 2.0f;

    public float rotSpeed = 3.0f;

    private void Awake()
    {
        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        for (; ; )
        {
            transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);
            yield return new WaitForSeconds(0.02f);
            yield return null;
        }
    }

    private void LeftCuc() => left = StartCoroutine(LeftRotCorutine());

    private void RightCuc() => right = StartCoroutine(RightRotCorutine());

    public void leftbutton()
    {
        Ref.Instance.LeftButton.image.sprite = Ref.Instance.Left_sprite.pressedSprite;
        LeftCuc();
    }

    public void rightbutton()
    {
        Ref.Instance.rightButton.image.sprite = Ref.Instance.Right_sprite.pressedSprite;
        RightCuc();
    }

    public void leftbuttonUp()
    {
        Ref.Instance.LeftButton.image.sprite = Ref.Instance.Left_sprite.disabledSprite;
        StopCoroutine(left);
    }

    public void rightbuttonUp()
    {
        Ref.Instance.rightButton.image.sprite = Ref.Instance.Right_sprite.disabledSprite;
        StopCoroutine(right);
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