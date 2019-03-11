using UnityEngine;

public class arrive : MonoBehaviour
{
    public Transform Player;
    public Transform DestinationPoint;
    public float distance = 1000.0f;

    private Vector3 dir;

    private Vector2 dirpos = Vector2.zero;

    private void Awake()
    {
        //Vector2 delta = Vector2.zero;
        //float rd = Random.Range(0.0f, 360.0f);
        //delta.x = Mathf.Cos(rd) * distance;
        //delta.y = Mathf.Cos(rd) * distance;

        DestinationPoint.transform.position = Player.transform.position + Vector3.forward * distance;
    }

    // Update is called once per frame
    private void Update()
    {
        var player = Player.position;
        var destinationPos = DestinationPoint.position;
        dir = destinationPos - player;
        Ref.Instance.Destination_text.text = (distance - dir.magnitude).ToString("0") + "m";

        UI_Angle();
    }

    private Vector2 AngelPos = Vector2.zero;
    private Vector2 ps = new Vector2();

    public void UI_Angle()
    {
        Vector3 worldArrow = Camera.main.WorldToScreenPoint(Player.transform.position);
        Ref.Instance.TargetDir_image.transform.position = worldArrow;

        var relative = Player.transform.InverseTransformPoint(DestinationPoint.transform.position); //타겟위치는 Vector3

        // 각도를 구합니다.
        var angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;

        //  Vector3 targetDir = DestinationPoint.transform.position - Player.transform.position;
        //  float angle2 = Vector3.Angle(targetDir, Player.transform.forward);

        // 캐릭터 회전
        Ref.Instance.TargetDir_image.transform.rotation = Quaternion.Euler(0, 0, -angle);
    }
}