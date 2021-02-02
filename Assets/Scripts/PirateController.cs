using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask playerLayerMask;
    private BoxCollider2D boxCollider2D;
    public Transform ShootPoint;
    public GameObject MusketBallPrefab;
    public Animator animator;
    private bool shotDone= true;
    void Start()
    {
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.left * 15, Color.green);
        if (Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.left ,15, playerLayerMask)){

           if(shotDone){
            shotDone = false;
            StartCoroutine(ShotWait());
            }

        }
    }
    IEnumerator ShotWait(){
            animator.SetBool("Shot", false);
            animator.Play("Pirate Shoot",  -1, 0f);
            yield return new WaitForSeconds(0.5f);
            animator.SetBool("Shot", true);
            Instantiate(MusketBallPrefab, ShootPoint.position, ShootPoint.rotation);
            yield return new WaitForSeconds(5);
            shotDone = true;
    }
}
