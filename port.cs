using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

using System;

public class port : MonoBehaviour
{
    public Player player;
    float delay;
    float intarziere = 5f;

    string date;

    // Start is called before the first frame update
    void Start()
    {
        delay = intarziere;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            SerialPort sp = new SerialPort("COM4", 9600);
            sp.Open();
            try
            {
                delay = intarziere;
                date = sp.ReadLine();
            }
            catch (TimeoutException)
            {
                date = null;
                delay = 0;
            }
            float z;
            if (date != null)
                z = float.Parse(date);
            else z = 0;
            if (z >= 0.9f)
            {
                player.xp += player.suma;
                z = 0;
            }
            sp.Close();
        }
    }
}
