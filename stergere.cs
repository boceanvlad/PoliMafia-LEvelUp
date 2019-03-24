using UnityEngine;
using System.Collections;

public class stergere : MonoBehaviour {
    //
    float timp;
    public float secdistrugere;
    // Use this for initialization
    void Start () {
        timp = secdistrugere;
	}
	
	// Update is called once per frame
	void Update () {
        timp -= Time.deltaTime;
        if (timp < 0)
            Destroy(this.gameObject);
	}
}
