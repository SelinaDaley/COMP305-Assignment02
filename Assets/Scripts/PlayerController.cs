using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public class Speed
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {
		
	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	public Boundary boundary;
	public float moveForce = 365f;
	public float maxSpeed = 6f;
	public float jumpForce = 700f;
	public Transform groundCheck;
		
	public GameObject shot1;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;
			
	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}
		
	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetButtonDown("Jump") && grounded)
		{
			jump = true;
		}

		this._CheckFire ();
	}

	private void _CheckFire()
	{
		if(Input.GetKey(KeyCode.B) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot1, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");

		anim.SetInteger("AnimState", 1);

		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce(Vector2.right * h * moveForce);

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
			
		if (rb2d.velocity.x == 0) {
			anim.SetInteger("AnimState", 0);

		}

		GetComponent<Rigidbody2D>().position = new Vector2 (			
                   Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
                   Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax));

		if (h > 0 && !facingRight) 
		{
			Flip ();
		}
		else if (h < 0 && facingRight)
		{
				Flip ();
		}

		if (jump)
		{
			//anim.SetTrigger("Jump");
			anim.SetInteger("AnimState", 2);
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}
		
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
