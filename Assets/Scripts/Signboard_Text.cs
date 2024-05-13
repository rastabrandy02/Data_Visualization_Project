using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Signboard_Text : MonoBehaviour
{
    [SerializeField] Image imageComponent;
    [SerializeField] Sprite[] sprites;

    int currentIndex;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OpenTextPanel()
    {
        if (sprites.Length != 0)
        {
            currentIndex = 0;
            imageComponent.sprite = sprites[currentIndex];
            
        }
    }
    
    public bool AdvanceMenuIndex()
    {
        if (currentIndex < sprites.Length - 1 && sprites.Length != 0)
        {
            currentIndex++;
            imageComponent.sprite = sprites[currentIndex];
            return true;
        }
        else
        {
            return false;
        }
    }
}
