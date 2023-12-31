﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public float speed = 10f;
	private int score = 0;
	public int health = 5;
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w"))
		{
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}
		if (Input.GetKey("a"))
		{
			rb.AddForce(-speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, -speed * Time.deltaTime);
		}
		if (Input.GetKey("d"))
		{
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}
		if (health == 0)
		{
			Debug.Log("Game Over!");
			SceneManager.LoadScene("maze");
			health = 5;
			score = 0;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log("Score: " + score);
            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
        }
		if (other.CompareTag("Trap"))
		{
			health--;
			Debug.Log("Health: " + health);
		}
		if (other.CompareTag("Goal"))
		{
			Debug.Log("You win!");
		}
	}
}
