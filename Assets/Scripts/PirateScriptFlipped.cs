using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateScriptFlipped : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask playerLayerMask;
    private BoxCollider2D boxCollider2D;
    public Transform ShootPoint;
    public GameObject MusketBallFlippedPrefab;
    public Animator animator;
    private bool shotDone = true;
    public AudioClip shotSound;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.right * 15, Color.green);
        if (Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.right, 15, playerLayerMask))
        {

            if (shotDone)
            {
                shotDone = false;
                StartCoroutine(ShotWait());
            }

        }
    }
    IEnumerator ShotWait()
    {
        //animator.SetBool("Shot", false);
        animator.Play("Pirate Shoot", -1, 0f);
        audioSource.PlayOneShot(shotSound, 1);
        yield return new WaitForSeconds(0.5f);
        //animator.SetBool("Shot", true);
        Instantiate(MusketBallFlippedPrefab, ShootPoint.position, ShootPoint.rotation);
        yield return new WaitForSeconds(5);
        shotDone = true;
    }
}
