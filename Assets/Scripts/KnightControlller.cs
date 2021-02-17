using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnightControlller : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;
    public int MovementSpeed = -8;
    public int tempSpeed;
    private Vector2 rayDirection = new Vector2(0,0);
    public int size = 12;
    private Vector3 theScale;
    private BoxCollider2D boxCollider2D;
    public Animator anim;
    public Animator animator;
    private bool movingLeft = true;
    private bool slashDone = true;
    public AudioClip slashSound;
    AudioSource audioSource;
    void Start()
    {
        theScale = transform.localScale;
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        tempSpeed = MovementSpeed;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3(MovementSpeed,0,0) * Time.deltaTime; //movement and movement animation
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
            
            StartCoroutine(TurnWait());
            
    }

    void FixedUpdate(){
        
        if(MovementSpeed < 0){
            movingLeft = true;
        }
        if(MovementSpeed > 0){
            movingLeft = false;
        }
        if(movingLeft){
            Debug.DrawRay(boxCollider2D.bounds.center, Vector2.left * 2, Color.green);
            rayDirection = Vector2.left;
        }

        if(!movingLeft){
            Debug.DrawRay(boxCollider2D.bounds.center, Vector2.right * 2, Color.green);
            rayDirection = Vector2.right;
        }

        if (Physics2D.Raycast(boxCollider2D.bounds.center, rayDirection ,2, playerLayerMask)){
            
            if(slashDone){
            slashDone = false;
            StartCoroutine(KillWait());
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collison){
        
    }
    IEnumerator TurnWait(){
    //Debug.Log("Died Wait");
            MovementSpeed = -MovementSpeed; 
            tempSpeed = MovementSpeed;
            yield return new WaitForSeconds(0.225f);
            size = -size;
            theScale.x = size;
            transform.localScale = theScale;
            //Debug.Log("Hit");
            
   
    }
    IEnumerator KillWait(){
        MovementSpeed = 0;
        animator.Play("Knight Slash",  -1, 0f);
        audioSource.PlayOneShot(slashSound, 1);
        yield return new WaitForSeconds(0.75f);
        if (Physics2D.Raycast(boxCollider2D.bounds.center, rayDirection ,2, playerLayerMask)){
             anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
             anim.Play("Player Death",  -1, 0f);
             Time.timeScale = 0;
             yield return new WaitForSecondsRealtime(1);
             SceneManager.LoadScene("FirstLevel");
             Time.timeScale = 1;
        }
        MovementSpeed = tempSpeed;
        slashDone = true;
    }
}
