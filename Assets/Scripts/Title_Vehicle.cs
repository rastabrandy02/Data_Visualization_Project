using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Vehicle : MonoBehaviour
{
    float speed;
    Transform target;
    SpriteRenderer spriteRend;
    bool activated = false;
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated) return;
        

        
        transform.position += new Vector3(speed, 0.0f) * Time.deltaTime;

        if(Mathf.Abs(transform.position.x) >= Mathf.Abs(target.position.x))
        {
            Destroy(gameObject);
        }
    }

    public void Activate(float speed, Transform target)
    {

        spriteRend = GetComponent<SpriteRenderer>();
        if (target.position.x > transform.position.x)
        {
            spriteRend.flipX = true;
        }
        else spriteRend.flipX = false;

        this.speed = speed;
        this.target = target;

        activated = true;
    }
}
