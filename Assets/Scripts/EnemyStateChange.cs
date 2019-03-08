using UnityEngine;

public class EnemyStateChange : MonoBehaviour
{
    public enum State { Waiting, Tracking, Attack }

    public State state = State.Waiting;

    private float distance;

    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    public void StateChange()
    {
        distance = Vector3.Distance(transform.position, enemy.target.transform.position);

        if (distance <= 1.0f)
        {
            state = State.Attack;
            Debug.Log("플레이어 공격~!");
            Rigidbody playerRid = enemy.target.GetComponent<Move>().rid;
            playerRid.velocity = Vector3.zero;
            playerRid.AddForce(-Vector3.forward * 30f, ForceMode.Impulse);
        }
        else
        {
            state = State.Tracking;
        }
    }
}