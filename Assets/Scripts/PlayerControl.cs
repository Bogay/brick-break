using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public float speed;

	private Transform self;
	private Vector3 speedV;

	// Use this for initialization
	void Start()
	{
		self = transform;
		speedV = Vector3.right * speed;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if(Input.GetKey(KeyCode.LeftArrow)) self.position -= speedV * Time.deltaTime;
		else if(Input.GetKey(KeyCode.RightArrow)) self.position += speedV * Time.deltaTime;
	}
}