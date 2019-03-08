using UnityEngine;
using UnityEngine.UI;

public class Ref : Singleton<Ref>
{
    public Text Destination_text = null;

    public Image TargetDir_image = null;

    [Header("왼쪽버튼")]
    public Button LeftButton;

    public SpriteState Left_sprite;

    [Header("오른쪽버튼")]
    public Button rightButton;

    public SpriteState Right_sprite;

    [Header("적 대기상태 Image")]
    public Image questionmark;

    [Header("적 추적상태 Image")]
    public Image pointer;

    public Canvas canvas;

    private void Start()
    {
        Screen.SetResolution(Screen.width, (Screen.width / 9) * 16, true);

        LeftButton.GetComponent<RectTransform>().sizeDelta = sizeDelta();

        rightButton.GetComponent<RectTransform>().sizeDelta = sizeDelta();

        Destination_text.GetComponent<RectTransform>().sizeDelta = sizeDelta();
    }

    private Vector2 sizeDelta()
    {
        Vector2 delta = new Vector2((Screen.width / 9) * 2, (Screen.height / 16) * 2);
        return delta;
    }
}