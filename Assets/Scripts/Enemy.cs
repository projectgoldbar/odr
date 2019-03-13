using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum State { IDLE, PATROL, DEAD };

public enum Pause { Stop = 0, Go }

public class Enemy : MonoBehaviour
{
    private State state = State.IDLE;

    private Pause pause;

    public Pause PAUSE
    {
        get { return pause; }
        set
        {
            pause = value;
            if (pause == Pause.Stop)
            {
                StartCoroutine(StopNGo(StopNGoTimer));
            }
        }
    }

    public Rigidbody rid;

    [Tooltip("게임시작시 플레이어를 찾아넣음")]
    public Player target = null;

    [Tooltip("경직 후 다시 움직일때까지의 시간")]
    public float StopNGoTimer = 3;

    private Coroutine Follow_OnOff;
    private Coroutine Processing;

    private Image stateImage;

    public EnemyData data;

    public void IsStop()
    {
        PAUSE = Pause.Stop;
    }

    public IEnumerator StopNGo(float time)
    {
        yield return new WaitForSeconds(time);
        PAUSE = Pause.Go;
    }

    private void Start()
    {
        Follow_OnOff = StartCoroutine(StateChage());
        Processing = StartCoroutine(Process());
        PAUSE = Pause.Go;
    }

    private void Awake()
    {
        target = FindObjectOfType<Player>();
        stateImage = Instantiate(Ref.Instance.questionmark, Ref.Instance.canvas.transform);
    }

    private void OnEnable()
    {
        if (!stateImage.gameObject.activeSelf)
            stateImage.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsStop();
        }
    }

    private IEnumerator StateChage()
    {
        for (; ; )
        {
            switch (state)
            {
                case State.IDLE:
                    stateImage.sprite = Ref.Instance.questionmark.sprite;
                    break;

                case State.PATROL:
                    Follow(target.transform);
                    break;

                case State.DEAD:
                    data.hp = 0;
                    break;
            }
            yield return new WaitForSeconds(0.02f);
            yield return null;
        }
    }

    private IEnumerator Process()
    {
        for (; ; )
        {
            stateImage_conversion();
            var magnitude = (target.transform.position - transform.position).magnitude;

            if (data.hp > 0)
            {
                if (magnitude <= 10)
                {
                    state = State.PATROL;
                }
                else
                {
                    state = State.IDLE;
                }
            }
            else
            {
                state = State.DEAD;
            }
            yield return new WaitForSeconds(0.02f);
            yield return null;
        }
    }

    private void Follow(Transform target)
    {
        var dir = Dircalculation(target.position, transform.position);

        if (PAUSE == Pause.Go)
        {
            stateImage.sprite = Ref.Instance.pointer.sprite;
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * data.speed * (int)PAUSE);

            rid.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * data.speed * (int)PAUSE);
        }
        else
        {
            stateImage.sprite = Ref.Instance.questionmark.sprite;
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