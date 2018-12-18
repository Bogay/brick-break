using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public float force;
	public float speed;

	private float delta = 20;
	private Vector2[] axesv = { Vector2.right, Vector2.up, Vector2.left, Vector2.down };
	private float[] axes = { 0, 90, 180, -90 };

	private Rigidbody2D rb2d;
	private float last;
	private float gap = 0.2f;

	void Start()
	{
		last = Time.time;
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.AddForce(Vector2.down * force);
	}

	
	// private void OnCollisionExit2D(Collision2D other)
	// {
	// 	if(Time.time - last < gap) return;
	// 	Debug.Log(other.gameObject.tag);
	// 	float angle;
	// 	float d, r;
		
	// 	for(int i=0 ; i<4 ; i++)
	// 	{
	// 		angle = Vector2.Angle(axesv[i], rb2d.velocity);
	// 		d = axes[i] - angle;
	// 		if(Mathf.Abs(angle) < delta)
	// 		{
	// 			r = (d + (delta + 5) * Mathf.Sign(d)) * Mathf.Sign(angle);
	// 			Debug.Log("roatation: " + r);
	// 			rb2d.velocity = Quaternion.Euler(0, 0, r) * rb2d.velocity;
	// 			break;
	// 		}
	// 	}
		
	// 	angle = Vector2.Angle(Vector2.right, rb2d.velocity);
	// 	Debug.Log(angle);
		
	// 	rb2d.velocity = rb2d.velocity.normalized * speed;
	// 	last = Time.time;
	// }
	

	// void OnCollisionExit2D(Collision2D collision)
    // {
    //     float angle = Mathf.Rad2Deg * Mathf.Atan2(rb2d.velocity.y, rb2d.velocity.x);
    //     float a = Mathf.Repeat(angle + 180f, 90f);
    //     float b = Mathf.Clamp(a, 20, 70);
	// 	Debug.Log(System.String.Format("angle, a, b = [{0}, {1}, {2}]", angle, a, b));
    //     angle = Mathf.Deg2Rad * (angle - a + b);
	// 	Debug.Log(System.String.Format("Fixed angle: {0}", angle));
    //     rb2d.velocity = speed * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    // }

	private void OnCollisionExit2D(Collision2D other)
	{
		float angle = Mathf.Rad2Deg * Mathf.Atan2(rb2d.velocity.y, rb2d.velocity.x);
		float a = (angle + 180) % 90f;
		float b = Mathf.Clamp(a, 20, 70);
		angle = Mathf.Deg2Rad * (angle - a + b);
		rb2d.velocity = speed * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
	}
}