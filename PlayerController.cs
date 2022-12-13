/*
Author: Alexis
Date Created: ???, 2017
Purpose: To control player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Include scene loading package

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
	
	bool facingRight = true;
	
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;


    public bool grounded = false;

    public AudioClip[] Sound;
    
    private Rigidbody2D rb;

    public AudioSource mySource;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
        {
			if(facingRight){
				flip();
                facingRight = !facingRight;	
			}
			rb.velocity = new Vector2(-speed, rb.velocity.y);
			
        }
        else if (Input.GetKey(right))
        {
            if(!facingRight){
				flip();
                facingRight = !facingRight;
            }
			rb.velocity = new Vector2(speed, rb.velocity.y);
			
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyDown(up))
        {
            if (grounded)
            {
                rb.AddForce(new Vector2(0, jumpPower));
                grounded = false;
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        if (col.gameObject.CompareTag("Monster Cream")) 
        {
            
            Destroy(col.gameObject);
            playSound(0);

        }
        if (col.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene("LevelTwoScene", LoadSceneMode.Single); //Tells computer to load scene/level
        }
        if (col.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadScene("CongratsScene", LoadSceneMode.Single); //Tells computer to load scene/level
        }
    }
	
	void flip(){
		Vector3 Scale = transform.localScale;
		Scale.x = Scale.x * -1;
		transform.localScale = Scale;
	}

    void playSound(int clip)
    {
        //mySource = GetComponent<AudioSource>();
        //GetComponent<AudioSource>().clip = Sound[clip];
        mySource.Play();
    }
}
