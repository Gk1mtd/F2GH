using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Use this for initialization
    void Start () {
        life = 10;
        speed = 5.0f;
        position = new Vector2(0, 0);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        meth_movement();
        meth_shoot();
    }

    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        Debug.Log("Got hit by something");
    }
    private void meth_shoot()
    {
        if (Input.GetAxis("TriggerRight") > 0.0f)
        {
            var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 6;

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2.0f);
        }
    }
    private void meth_movement()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
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

}