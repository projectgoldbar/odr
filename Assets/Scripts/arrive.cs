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
        dir = (DestinationPoint.position - Player.position);
        Ref.Instance.Destination_text.text = (distance - dir.magnitude).ToString("0") + "m";

        UI_Angle();
    }

    public void UI_Angle()
    {
        Vector3 worldArrow = Camera.main.WorldToScreenPoint(Player.transform.position);
        Ref.Instance.TargetDir_image.transform.position = worldArrow;
        var AngleDir = dir.normalized;
        float Angle = Mathf.Atan2(AngleDir.x, AngleDir.z) * Mathf.Rad2Deg;

        Ref.Instance.TargetDir_image.transform.eulerAngles = new Vector3(0, 0, -Angle);
    }
}