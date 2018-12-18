using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public float speed;
	public float forceScalor;

	private Transform self;
	private Rigidbody2D rb2d;
	private Vector3 speedV;

	// Use this for initialization
	void Start()
	{
		self = transform;
		rb2d = GetComponent<Rigidbody2D>();
		speedV = Vector3.right * speed;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if(Input.GetKey(KeyCode.LeftArrow)) self.position -= speedV * Time.deltaTime;
		else if(Input.GetKey(KeyCode.RightArrow)) self.position += speedV * Time.deltaTime;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			//Debug.Log(System.String.Format("{0}, {1}", other.contacts[0].point, self.position));
			float temp = other.contacts[0].point.x - self.position.x;
			other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * (temp * forceScalor));
		}
	}
}