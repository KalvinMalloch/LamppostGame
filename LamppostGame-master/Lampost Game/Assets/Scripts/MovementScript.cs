using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public bool moveControls;
	public bool grounded;
    public bool inLight;
	public float jumpPower = 250f;
	public float speed = 1f;
    public float depression = 100f;
    public float depressionSpeed = 0.1f;
	Animator anim;
	Light glow;

    void Awake () 
    {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		glow = GetComponent<Light> ();
		moveControls = true;
        inLight = false;
		grounded = true;
		Time.timeScale = 1;
	}
	
    void Update() 
    {
        PlayerInLight();
		LightDim();
		anim.SetBool ("IsRunning", true);
		float horizontal = Input.GetAxis ("Horizontal");
        if (moveControls == true) {
			Movement (horizontal);
			if (Input.GetButtonDown("Jump") & (grounded == true)) {
				anim.SetBool ("IsRunning", false);
				rb2d.AddForce(Vector2.up * jumpPower);
				grounded = false;
			}
		}
    }
	
    void PlayerInLight()
    {
        if (inLight == false) 
        {
            depression = depression - (Time.deltaTime * depressionSpeed);
            depressionSpeed = depressionSpeed + (Time.deltaTime * 0.5f);
        }
        if (inLight == true && depression <= 100)
        {
            depression = depression + (Time.deltaTime * depressionSpeed);
        }
        if (depression > 100)
        {
            depression = 100;
        }
    }
	
	void LightDim() 
	{
		glow.intensity = depression/2;
	}
	
	private void Movement (float horizontal) 
    {
		rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);
		if (((Input.GetKey(KeyCode.A) == true) || (Input.GetKey(KeyCode.D) == true)) && (grounded == true)) {
			anim.SetBool ("IsRunning", true);
		} else if ((Input.GetKey(KeyCode.A) == false) || (Input.GetKey(KeyCode.D) == false)) {
			anim.SetBool ("IsRunning", false);
		}
		if (Input.GetKey(KeyCode.A) == true) {
			transform.localScale = new Vector3(-6, 6, 1);
		}
		if (Input.GetKey(KeyCode.D) == true) {
			transform.localScale = new Vector3(6, 6, 1);
		}
		
	}

    void OnTriggerStay2D(Collider2D Lamp)
    {
        if (Lamp.tag == "Light")
        {
            inLight = true;
        } else {
			inLight = false;
		}
    }


    void OnTriggerEnter2D(Collider2D Ground)
    {
        if (Ground.tag == "Ground")
        {
            grounded = true;
        }
    }
}