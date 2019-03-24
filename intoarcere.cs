using UnityEngine;
using System.Collections;

public class intoarcere : MonoBehaviour {
    public float timpintoarcere;
    public bool intors = false;
	// Use this for initialization
    //
	void Start () {
	
	}
    void intoarce()
    {
        this.GetComponent<Movable>().direction.x = -this.GetComponent<Movable>().direction.x;

    }
	// Update is called once per frame
	void Update () {
        if (timpintoarcere > 0 && intors==false)
            timpintoarcere -= Time.deltaTime;
        if (timpintoarcere <= 0 && intors == false)
        { intoarce(); intors = true; }
	}
}
