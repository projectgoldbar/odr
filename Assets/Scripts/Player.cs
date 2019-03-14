using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Scrollbar Hpbar;

    public float MaxHp;

    private float hp;

    private Animator Anim;

    public float Hp
    {
        get => hp;
        set
        {
            hp = value;
            if (hp <= 0)
            {
                Debug.Log("플레이어 사망");
                Anim.SetTrigger("Dead");

                Invoke("Gameover", 3.0f);
            }
            else
                Hpbar.value = (Hp / MaxHp);
        }
    }

    public void Gameover()
    {
        SceneManager.LoadScene(0);
    }

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        Hp = MaxHp;
    }
}