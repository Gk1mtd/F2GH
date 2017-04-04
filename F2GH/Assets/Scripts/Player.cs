using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {
    
	// Use this for initialization
	void Start () {
        life = 10;
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void meth_shoot()
    {
        Debug.Log("I´ve fired!");
    }
}