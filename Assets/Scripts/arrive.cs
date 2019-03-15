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
        DestinationPoint.transform.position = Player.transform.position + Vector3.forward * distance;
    }

    // Update is called once per frame
    private void Update()
    {
        var player = Player.position;
        var destinationPos = DestinationPoint.position;
        dir = destinationPos - player;
        dirDis = dir.magnitude;
        var Prog_dis = distance - dirDis;
        Ref.Instance.Destination_text.text = Prog_dis.ToString("0") + "m";

        if (Prog_dis < 0) Ref.Instance.Destination_text.color = Color.red;
        else Ref.Instance.Destination_text.color = Color.white;
    }
}