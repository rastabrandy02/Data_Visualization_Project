using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float interactRange;
    public GameObject exclamation;
    public bool movingPlayer;
    public bool playerInMenu;
    public bool isInInteractRange;
    public Animator animator;

    Collider2D lastCollision;
    void Start()
    {
        movingPlayer = false;
        playerInMenu = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && !playerInMenu)
        {
            Walk(Vector2.up);
        }
        if (Input.GetKey(KeyCode.A) && !playerInMenu)
        {
            Walk(-Vector2.right);
        }
        if (Input.GetKey(KeyCode.S) && !playerInMenu)
        {
            Walk(-Vector2.up);
        }
        if (Input.GetKey(KeyCode.D) && !playerInMenu)
        {
            Walk(Vector2.right);
        }


        if (!Input.anyKey)
        {
            movingPlayer = false;
            
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || 
            Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) && !playerInMenu)
        {
            movingPlayer = false;
            animator.SetBool("isMoving", movingPlayer);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isInInteractRange)
        {
            Interact();
        }
        if(lastCollision != null) CheckCollisionRange();
        animator.SetBool("isMoving", movingPlayer);
        
    }

    void Walk(Vector2 direction)
    {
        movingPlayer = true;
        gameObject.transform.position += new Vector3(direction.normalized.x * speed, direction.normalized.y * speed) * Time.deltaTime;
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
        animator.SetBool("isMoving", movingPlayer);
    }
    void Interact()
    {
        Signboard signboard;

        if (playerInMenu)
        {          
            if (lastCollision.gameObject.TryGetComponent(out signboard))
            {
                movingPlayer = false;
                playerInMenu = false;
                signboard.CloseUIMenu();
            }                
        }
        else
        {           
            if(lastCollision.gameObject.TryGetComponent(out signboard))
            {
                movingPlayer = false;
                playerInMenu = true;
                signboard.OpenUIMenu();
            }       
        }
    }
    void CheckCollisionRange()
    {

        if(Vector2.Distance(transform.position, lastCollision.transform.position) > interactRange)
        {
            isInInteractRange = false;
            playerInMenu = false;
            exclamation.SetActive(false);
        }
        if (Vector2.Distance(transform.position, lastCollision.transform.position) > interactRange * 3)
        {
            lastCollision = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            lastCollision = collision;
            isInInteractRange = true;
            exclamation.SetActive(true);
        }
    }


   
}
    
