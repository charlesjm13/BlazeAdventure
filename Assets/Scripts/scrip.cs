﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading;
using UnityEngine.SceneManagement;


public class scrip : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    public GameObject Player;
    public float distanceGround;
    public float MovementSpeed = 40;
    public float JumpForce = 5f;
    public Animator animator;
    public RigidbodyConstraints2D originalConstraints;
    public bool isGrounded = false;
    //public LayerMask groundLayers;
    private Rigidbody2D rigidbody;
    public float fallMultiplier = -5;
    private BoxCollider2D boxCollider2D;
    //public bool ableToMove = true;
    //public GameObject killed;
    //public Collision2D collison;
    public AudioClip grabBag;
    public AudioClip jump;
    //public AudioClip deathMusic;
    AudioSource audioSource;

	public void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
        originalConstraints = rigidbody.constraints;
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
	}

	public void Update(){
        //if(ableToMove){
        
        if(Input.GetButtonDown("Jump" )&& isGrounded){
                audioSource.PlayOneShot(jump, 1);
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, JumpForce);
                isGrounded = false;
                animator.Play("Player Jump",  -1, 0f);
         }
        if(rigidbody.velocity.y <= 0){
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, fallMultiplier);
                animator.SetBool("Jumped", false);
        }
		var movement = Input.GetAxis("Horizontal"); //setting movement var and charachter handler
        if(movement < 0){
            Vector3 theScale = transform.localScale;
            theScale.x = -100;
            transform.localScale = theScale;
        }
        if(movement > 0){
            Vector3 theScale = transform.localScale;
            theScale.x = 100;
            transform.localScale = theScale;
        }

		transform.position += new Vector3(movement,0,0) * Time.deltaTime * MovementSpeed; //movement and movement animation
        animator.SetFloat("Speed", Math.Abs(movement));
        //} 
	}
    
    void FixedUpdate() {
        //RaycastHit hit = Physics.Raycast(transform.position, -Vector3.up, distanceGround+0.5f);
        distanceGround = 0.1f;
        if(!Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, -Vector2.up, distanceGround, groundLayerMask)){
            isGrounded = false;
            //Debug.Log("Air");
            //Debug.DrawRay(transform.position, -Vector3.up, Color.green); 
        }
        else{
            isGrounded = true;
        }
    }
	private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.CompareTag("StompZone")){
            GameObject body = collider.gameObject;
            GameObject bodyParent = body.transform.parent.gameObject;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, JumpForce);
            StartCoroutine(DoEnemyDeathAnimation(bodyParent));
            PayerScore.currentScore += 1;
            PayerScore.score += 1;
            KillManager.KillAmount = PayerScore.currentScore;

        }
        if(collider.gameObject.CompareTag("Enemy")){
            //Debug.Log("Deaded");
            
            StartCoroutine(DoPlayerDeathAnimation());
        }
        if(collider.gameObject.CompareTag("Collectibles")){
            Debug.Log("Collected");
            audioSource.PlayOneShot(grabBag, 1);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collider){
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Spikes"))
        {
            StartCoroutine(DoPlayerDeathAnimation());
            PayerScore.score = 0;
            PayerScore.currentScore = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collison){
        
    }
IEnumerator DoEnemyDeathAnimation(GameObject g)
 {
   //Debug.Log("Animated Wait");
   yield return new WaitForSeconds(0.5f); // wait for two seconds.
   Destroy(g);
   //Debug.Log("This happens 2 seconds later. Tada.");
 }
 IEnumerator DoPlayerDeathAnimation()
 {
    //Debug.Log("Died Wait");
    animator.Play("Player Death",  -1, 0f);
    //audioSource.Stop();
    //audioSource.PlayOneShot(deathMusic, 1);    
    Time.timeScale = 0;
    //Debug.Log("Entered");
   yield return new WaitForSecondsRealtime(1); // wait four seconds.
   SceneManager.LoadScene("FirstLevel");
   //Debug.Log("Exited");
   Time.timeScale = 1;
   
 }
}
