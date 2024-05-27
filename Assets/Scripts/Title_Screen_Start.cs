using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Screen_Start : MonoBehaviour
{
    [SerializeField] GameObject textChild;
    Animator anim;
     public bool activated = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !activated)
        {
            activated = true;
            StartAnimation();
        }
    }

    void StartAnimation()
    {
        anim.SetTrigger("Activated");
    }

    public void LoadGame()
    {
        textChild.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }
}
