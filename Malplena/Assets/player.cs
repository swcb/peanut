using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	public float speed = 5.0f;
	public float jumpforce;
	bool isjumping;
	Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D> ();
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
		float horizonte = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizonte);
		transform.Translate(Vector3.up * (Time.deltaTime * speed  * vertical));
		jump();
    }
	
	void jump(){
		if(Input.GetKeyDown(KeyCode.Space) && !isjumping){
			isjumping = true;
			rb.AddForce(new Vector2 (rb.velocity.x, jumpforce));
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.CompareTag("Ground")){
			isjumping = false;
			
			rb.velocity = Vector2.zero;
		}
		
	}
}
