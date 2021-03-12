using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
    public bool checkTriggerd =false;
    //public LayerMask groundLayers;
    private Rigidbody2D rigidbody;
    public float fallMultiplier = -5;
    private BoxCollider2D boxCollider2D;
    //public bool ableToMove = true;
    //public GameObject killed;
    //public Collision2D collison;
    public AudioClip grabBag;
    public AudioClip jump;
    public Vector2 spawnPoint;
    //public AudioClip deathMusic;
    AudioSource audioSource;
    public Image checkpointPopUp;
    
  //public bool checkpointed;

  

	public void Start(){
        int died = PlayerPrefs.GetInt("died");
        if(died == 0){
            PlayerPrefs.SetInt("lifeAmount", 3);
        }
        rigidbody = GetComponent<Rigidbody2D>();
        originalConstraints = rigidbody.constraints;
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        float playerPositionX = PlayerPrefs.GetFloat("playerPositionX");
        float playerPositionY = PlayerPrefs.GetFloat("playerPositionY");
        int checkpointed = PlayerPrefs.GetInt("checkpointed");
        spawnPoint = this.transform.position;
        if(checkpointed != 0){
        spawnPoint = new Vector2(playerPositionX, playerPositionY);
        this.transform.position = spawnPoint;
        }
    
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
        if(Input.GetKeyDown(KeyCode.F) && checkTriggerd == true){
                Debug.Log("triggered2");
                PlayerPrefs.SetFloat("playerPositionX", this.transform.position.x);
                PlayerPrefs.SetFloat("playerPositionY", this.transform.position.y);
                PlayerPrefs.Save();
                checkpointPopUp.gameObject.SetActive(true);
                StartCoroutine(CheckpointWait());
                PlayerPrefs.SetInt("checkpointed", 1);

                spawnPoint = this.transform.position;
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
            int kills = PlayerPrefs.GetInt("kills");
            PlayerPrefs.SetInt("kills", kills + 1);
            PlayerPrefs.Save();

        }
        if(collider.gameObject.CompareTag("Enemy")){
            //Debug.Log("Deaded");
            
            StartCoroutine(DoPlayerDeathAnimation());
        }
        if(collider.gameObject.CompareTag("Collectibles")){
            Debug.Log("Collected");
            audioSource.PlayOneShot(grabBag, 1);
        }
        if(collider.gameObject.CompareTag("Checkpoint")){
            Debug.Log("triggered1");
            checkTriggerd = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider){
        checkTriggerd = false;
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Spikes"))
        {
            //Debug.Log("Died via Collision");
            StartCoroutine(DoPlayerDeathAnimation());
            
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
 IEnumerator CheckpointWait()
 {
   //Debug.Log("Animated Wait");
   yield return new WaitForSeconds(1.5f); // wait for two seconds.
   checkpointPopUp.gameObject.SetActive(false);
   //Debug.Log("This happens 2 seconds later. Tada.");
 }
 IEnumerator DoPlayerDeathAnimation()
 {
    //Debug.Log("Died Wait");
    animator.Play("Player Death",  -1, 0f);
    int temp = PlayerPrefs.GetInt("lifeAmount");
    PlayerPrefs.SetInt("lifeAmount", temp - 1);
    PlayerPrefs.SetInt("died", 1);
    PlayerPrefs.Save();
    //audioSource.Stop();
    //audioSource.PlayOneShot(deathMusic, 1);    
    Time.timeScale = 0;
    //Debug.Log("Entered");
   yield return new WaitForSecondsRealtime(1); // wait four seconds.
   this.transform.position = spawnPoint;
   //SceneManager.LoadScene("FirstLevel");
   //Debug.Log("Exited");
   Time.timeScale = 1;
   
 }
}
