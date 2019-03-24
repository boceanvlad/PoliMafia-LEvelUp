using UnityEngine;
using System.Collections;

public class undita : MonoBehaviour
{
    //
    int activat = 0;
    public GameObject player;
    public GameObject ac;
    float timp;
    public float spawnFrequencyInSeconds;
    // Use this for initialization
    void Start()
    {
        timp = spawnFrequencyInSeconds;
    }
    void OnTriggerStay2D(Collider2D col)
    {

            activat = 1;

    }
    void OnTriggerExit2D(Collider2D col)
    { activat = 0;
    }
    // Update is called once per frame
    void Update()
    {

        timp -= Time.deltaTime;
        if (activat == 1)
        {
            if (Input.GetMouseButton(0))

                if (timp < 0)
                {
                    timp = spawnFrequencyInSeconds;
                    Instantiate(ac);
                }

        }
    }
}
