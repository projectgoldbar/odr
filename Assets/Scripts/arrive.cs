using UnityEngine;

public class arrive : MonoBehaviour
{
    public Transform Player;
    public Transform DestinationPoint;
    public float distance = 1000.0f;

    private Vector3 dir;

    private Vector3 Myself = Vector2.zero;
    private float dirDis;

    private void Awake()
    {
        //Vector2 delta = Vector2.zero;
        //float rd = Random.Range(0.0f, 360.0f);
        //delta.x = Mathf.Cos(rd) * distance;
        //delta.y = Mathf.Cos(rd) * distance;
        Myself = Ref.Instance.TargetDir_image.transform.position;
        DestinationPoint.transform.position = Player.transform.position + Vector3.forward * distance;
    }

    // Update is called once per frame
    private void Update()
    {
        var player = Player.position;
        var destinationPos = DestinationPoint.position;
        dir = destinationPos - player;
        dirDis = dir.magnitude;
        Ref.Instance.Destination_text.text = (distance - (distance - dirDis)).ToString("0") + "m";

        UI_Angle();
    }

    private Vector2 AngelPos = Vector2.zero;
    private Vector2 ps = new Vector2();

    public void UI_Angle()
    {
        Vector3 worldArrow = Camera.main.WorldToScreenPoint(Player.transform.position);
        // Ref.Instance.TargetDir_image.transform.position = worldArrow;

        var angle = Quaternion.LookRotation(dir).eulerAngles.y;

        // UI 회전
        Ref.Instance.TargetDir_image.transform.eulerAngles
            = new Vector3(0, 0, -angle);

        Ref.Instance.TargetDir_image.transform.position =
            Myself + (dir * dirDis);

        Debug.Log(dir);
    }
}