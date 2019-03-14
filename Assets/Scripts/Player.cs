using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Scrollbar Hpbar;

    public float MaxHp;

    private float hp;

    public float Hp
    {
        get => hp;
        set
        {
            hp = value;
            Hpbar.value = (Hp / MaxHp);
        }
    }

    private void Awake()
    {
        Hp = MaxHp;
    }
}