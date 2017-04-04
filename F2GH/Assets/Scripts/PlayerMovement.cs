using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Entity {
    Vector2 position;
	// Use this for initialization
	void Start () {
        position = new Vector2(0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        var x2 = -Input.GetAxis("HorizontalRight");
        var y2 = Input.GetAxis("VerticalRight");

        if (x2 != 0 || y2 != 0)
        {
            float heading = Mathf.Atan2(x2, y2);
            transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);
        }
        if (x != 0 || y != 0)
        {
            position = position + new Vector2(x, y);
            transform.position = position;
        }
    }

    private void meth_shoot()
    {
        Debug.Log("I´ve fired!");
    }
}