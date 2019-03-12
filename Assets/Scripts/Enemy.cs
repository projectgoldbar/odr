using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private float runSpeed;
    private float rotSpeed;

    public Rigidbody rid;
    public float stopshame = 1;

    [Tooltip("게임시작시 플레이어를 찾아넣음")]
    public Player target = null;

    private Coroutine Follow_OnOff;

    private Image stateImage;

    // private EnemyStateChange statechange;

    private void Awake()
    {
        //  statechange = GetComponent<EnemyStateChange>();
        target = FindObjectOfType<Player>();
        runSpeed = target.GetComponent<Move>().runSpeed - 1;
        rotSpeed = target.GetComponent<Move>().rotSpeed + 3.0f;
        stateImage = Instantiate(Ref.Instance.questionmark, Ref.Instance.canvas.transform);
    }

    private void Start()
    {
        StartCoroutine(stateImagePos());
    }

    private IEnumerator stateImagePos()
    {
        for (; ; )
        {
            if (stateImage != null)
                stateImage_conversion();

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (stopshame == 1)
        {
            var target = other.gameObject.GetComponent<Player>();
            if (target == null) return;

            //  statechange.state = EnemyStateChange.State.Tracking;
            stateImage.sprite = Ref.Instance.pointer.sprite;
            Follow_OnOff = StartCoroutine(Follow(target.transform));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (stopshame == 1)
        {
            var target = other.gameObject.GetComponent<Player>();
            if (target == null) return;

            //  statechange.state = EnemyStateChange.State.Waiting;
            stateImage.sprite = Ref.Instance.questionmark.sprite;
            StopCoroutine(Follow_OnOff);
        }
    }

    private IEnumerator Follow(Transform target)
    {
        for (; ; )
        {
            stateImage_conversion();

            var dir = Dircalculation(target.position, transform.position);
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotSpeed * stopshame);

            rid.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * runSpeed * stopshame);

            //  statechange.StateChange();
            //yield return new WaitForSeconds(0.02f);
            yield return null;
        }
    }

    private Vector3 Dircalculation(Vector3 target, Vector3 tr)
    {
        var dir = target - tr;
        var dirN = dir.normalized;
        dirN.y = 0;

        return dirN;
    }

    private void stateImage_conversion()
    {
        Vector3 convertion = Camera.main.WorldToScreenPoint(transform.position);
        stateImage.transform.position = convertion;
    }
}