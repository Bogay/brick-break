using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public float speed;
	public float forceScalor;

	private Rigidbody2D rb2d;
	private Transform self;

	void Start()
	{
		self = transform;
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = Vector2.down * speed;
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		float angle = Mathf.Rad2Deg * Mathf.Atan2(rb2d.velocity.y, rb2d.velocity.x);
		float a = (angle + 180) % 90f;
		float b = Mathf.Clamp(a, 20, 70);
		angle = Mathf.Deg2Rad * (angle - a + b);
		rb2d.velocity = speed * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "GameController")
		{
			//Debug.Log(System.String.Format("{0}, {1}", other.contacts[0].point, self.position));
			float temp = self.position.x - other.transform.position.x;
			if(Mathf.Abs(temp) > 1)
				temp = temp * 1 / Mathf.Abs(temp);
			print(temp);
			rb2d.AddForce(Vector2.right * (temp * forceScalor));
		}
	}
}