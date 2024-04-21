using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum VehicleType
{
    CICLOMOTOR,
    MOTO,
    COCHE,
    FURGONETA,
    CAMION
}
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
        
    }
    public void CloseUIMenu()
    {
        UIMenu.SetActive(false);
    }
}
