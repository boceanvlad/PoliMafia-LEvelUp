using UnityEngine;
using System.Collections;

public class abcd : MonoBehaviour {

    private Vector2 veloity;

    public float smoothTimey;
    public float smoothTimex;

    public GameObject prayer;
    public GameObject triger;

    void Start()
    {
        prayer = GameObject.FindGameObjectWithTag("Player");
        triger = GameObject.FindGameObjectWithTag("pauza");
    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(prayer.transform.position.x, prayer.transform.position.x, ref veloity.x, smoothTimex);
        float posY = Mathf.SmoothDamp(prayer.transform.position.y, prayer.transform.position.y, ref veloity.x, smoothTimey);
        float pos1X = Mathf.SmoothDamp(triger.transform.position.x, triger.transform.position.x, ref veloity.x, smoothTimex);
        float pos1Y = Mathf.SmoothDamp(triger.transform.position.y, triger.transform.position.y, ref veloity.x, smoothTimey);
        if (Mathf.Abs(posX - pos1X) <= 0.3 && Mathf.Abs(posY-pos1Y)<=0.3)
            prayer.transform.position = new Vector3(posX+1, posY+3, transform.position.z);

    }
}
