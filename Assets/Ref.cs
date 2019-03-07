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
}