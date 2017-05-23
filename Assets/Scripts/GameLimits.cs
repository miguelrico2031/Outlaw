using UnityEngine;

public class GameLimits : MonoBehaviour
{
    public Transform top;
    public Transform bottom;
    public Transform left;
    public Transform right;
    private float height;
    private float width;

    public float topOffset=2;

	// Use this for initialization
	void Start ()
	{
        width = Camera.main.aspect*Camera.main.orthographicSize *2;
	    height = Camera.main.orthographicSize*2;

        top.localScale=new Vector3(width,0);
        bottom.localScale=new Vector3(width,0);
        left.localScale=new Vector3(height,0);
        right.localScale=new Vector3(height,0);

        top.localPosition=new Vector3(0,height/2-topOffset);
        bottom.localPosition=new Vector3(0,height/-2);
        left.localPosition=new Vector3(width/-2,0);
        right.localPosition=new Vector3(width/2,0);
    }
}
