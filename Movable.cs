using UnityEngine;
using System.Collections;
using System;

public class Movable : MonoBehaviour
{
    //
    public Vector3 direction;
    public bool randomspeed=false;
    public float speed;
    public float timpdistrugere;
    // Use this for initialization
    void Start ()
    {
        System.Random x=new System.Random();
        if(randomspeed)
        speed = x.Next(3, 15);
        direction.Normalize();
        // Destroy this object after 10 seconds
        Destroy(gameObject, timpdistrugere);
    }
	
    // Update is called once per frame
    void Update ()
    {
        Vector3 newPosition = transform.localPosition + direction * speed*Time.deltaTime;
        transform.localPosition = newPosition;
    }
}
