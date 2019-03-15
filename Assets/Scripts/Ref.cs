using UnityEngine;
using UnityEngine.UI;

public class Ref : Singleton<Ref>
{
    public Text Destination_text = null;

    [Header("적 대기상태 Image")]
    public Image questionmark;

    [Header("적 추적상태 Image")]
    public Image pointer;

    public Canvas canvas;

    public float PlayerRoty;

    private void Start()
    {
        Screen.SetResolution(Screen.width, (Screen.width / 9) * 16, true);
    }
}