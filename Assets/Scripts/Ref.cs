using UnityEngine;
using UnityEngine.UI;

public class Ref : Singleton<Ref>
{
    public Text Destination_text = null;

    public Image TargetDir_image = null;

    [Header("적 대기상태 Image")]
    public Image questionmark;

    [Header("적 추적상태 Image")]
    public Image pointer;

    public Canvas canvas;

    public float PlayerRoty;

    private void Start()
    {
        Screen.SetResolution(Screen.width, (Screen.width / 9) * 16, true);

        Destination_text.GetComponent<RectTransform>().sizeDelta = sizeDelta();
    }

    private Vector2 sizeDelta()
    {
        Vector2 delta = new Vector2((Screen.width / 9) * 2, (Screen.height / 16) * 2);
        return delta;
    }
}