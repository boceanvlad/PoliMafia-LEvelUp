using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {
    //
    public float timpspawn;
    float timp;
    public GameObject peste;
    // Use this for initialization
    void Start () {
        timp = timpspawn;
	}
	
	// Update is called once per frame
	void Update () {
        timp -= Time.deltaTime;
        if(timp<0)
        { timp = timpspawn;
            Instantiate(peste);
        }
	}
}
