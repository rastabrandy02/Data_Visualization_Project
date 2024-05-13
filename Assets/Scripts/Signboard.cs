using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Signboard : MonoBehaviour
{
    public VehicleType type;
    public GameObject UIMenu;
    public bool isGraph;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void OpenUIMenuGraph()
    {
        UIMenu.SetActive(true);
        if(isGraph)
        {
            UIMenu.GetComponent<UI_Menu>().OpenGrafic(type, GraphType.ANTIGUITAT);
        }
        
        else
        {
            UIMenu.GetComponent<Signboard_Text>().OpenTextPanel();
        }
        
    }
    public void OpenUIMenuText()
    {
        UIMenu.SetActive(true);
    }
    public void CloseUIMenu()
    {
        UIMenu.SetActive(false);
    }
    public bool AdvanceUIMenu()
    {
        return UIMenu.GetComponent<Signboard_Text>().AdvanceMenuIndex();               
    }
}
