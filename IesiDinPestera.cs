using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IesiDinPestera : MonoBehaviour
{
    //
    private Vector2 veloity;

    public float smoothTimey;
    public float smoothTimex;

    public GameObject prayer;
    public GameObject triger;

    void Start()
    {
        prayer = GameObject.FindGameObjectWithTag("iesiPesteraPlayer");
        triger = GameObject.FindGameObjectWithTag("iesiPesteraTrigger");
    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(prayer.transform.position.x, prayer.transform.position.x, ref veloity.x, smoothTimex);
        float posY = Mathf.SmoothDamp(prayer.transform.position.y, prayer.transform.position.y, ref veloity.x, smoothTimey);
        float pos1X = Mathf.SmoothDamp(triger.transform.position.x, triger.transform.position.x, ref veloity.x, smoothTimex);
        float pos1Y = Mathf.SmoothDamp(triger.transform.position.y, triger.transform.position.y, ref veloity.x, smoothTimey);
        if (Mathf.Abs(posX - pos1X) <= 2 && Mathf.Abs(posY - pos1Y) <= 2)
            if (Input.GetKey("e"))
                //Application.LoadLevel(1);
                SceneManager.LoadScene(1);

    }
};
