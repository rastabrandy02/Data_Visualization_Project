using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public bool movingPlayer;
    public bool playerInMenu;
    public bool InteractRange;


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


        if (!Input.anyKey) movingPlayer = false;

       
        if(Input.GetKeyDown(KeyCode.Space) && InteractRange)
        {
            Interact();
        }

    }

    void Walk(Vector2 direction)
    {
        movingPlayer = true;
        gameObject.transform.position += new Vector3(direction.normalized.x * speed, direction.normalized.y * speed) * Time.deltaTime;

    }
    void Interact()
    {
        if(playerInMenu)
        {
            movingPlayer = false;
            playerInMenu = false;
            lastCollision.gameObject.GetComponent<Signboard>().CloseUIMenu();
        }
        else
        {
            movingPlayer = false;
            playerInMenu = true;
            lastCollision.gameObject.GetComponent<Signboard>().OpenUIMenu();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            lastCollision = collision;
            InteractRange = true;            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        InteractRange = false;
        playerInMenu = false;
    }
}
    
