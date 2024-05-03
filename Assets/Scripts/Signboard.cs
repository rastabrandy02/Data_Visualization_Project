using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Signboard : MonoBehaviour
{
    public VehicleType type;
    public GameObject UIMenu;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void OpenUIMenu()
    {
        UIMenu.SetActive(true);
        UIMenu.GetComponent<UI_Menu>().OpenGrafic(type, GraphType.ANTIGUITAT);
        
    }
    public void CloseUIMenu()
    {
        UIMenu.SetActive(false);
    }
}
