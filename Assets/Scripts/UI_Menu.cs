using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum VehicleType
{
    COCHE,
    MOTO,   
    CICLOMOTOR,
    FURGONETA,
    CAMION
}

public enum GraphType
{
    ANTIGUITAT,
    AMBIENTAL
}
public class UI_Menu : MonoBehaviour
{
    [SerializeField] Image imageComponent;

    [Header("Antiguitat")]
    [SerializeField] Sprite grafAntiguitatCoche;
    [SerializeField] Sprite grafAntiguitatMoto;
    [SerializeField] Sprite grafAntiguitatCiclomotor;
    [SerializeField] Sprite grafAntiguitatFurgoneta;
    [SerializeField] Sprite grafAntiguitatCamio;

    [Header("Ambiental")]
    [SerializeField] Sprite grafAmbientalCoche;
    [SerializeField] Sprite grafAmbientalMoto;
    [SerializeField] Sprite grafAmbientalCiclomotor;
    [SerializeField] Sprite grafAmbientalFurgoneta;
    [SerializeField] Sprite grafAmbientalCamio;


    VehicleType currentVehicle;
    GraphType currentGraph;

    int numberOfVehicleTypes;
    int numberOfGraphTypes;
    private void Awake()
    {
        numberOfVehicleTypes = System.Enum.GetValues(typeof(VehicleType)).Length;
        numberOfGraphTypes = System.Enum.GetValues(typeof (GraphType)).Length;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
        {
            SwapGraphType();
        }

        else if(Input.GetKeyDown(KeyCode.D))
        {
            SwapVehicleType(true);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            SwapVehicleType(false);
        }
    }

   public void OpenGrafic(VehicleType vehicleType, GraphType graphType)
   {
        if(graphType == GraphType.ANTIGUITAT)
        {
            switch (vehicleType)
            {
                case VehicleType.COCHE:
                    {
                        imageComponent.sprite = grafAntiguitatCoche;
                        currentVehicle = VehicleType.COCHE;
                        break;
                    }
                case VehicleType.MOTO:
                    {
                        imageComponent.sprite = grafAntiguitatMoto;
                        currentVehicle = VehicleType.MOTO;
                        break;
                    }
                case VehicleType.CICLOMOTOR:
                    {
                        imageComponent.sprite = grafAntiguitatCiclomotor;
                        currentVehicle = VehicleType.CICLOMOTOR;
                        break;
                    }
                case VehicleType.FURGONETA:
                    {
                        imageComponent.sprite = grafAntiguitatFurgoneta;
                        currentVehicle = VehicleType.FURGONETA;
                        break;
                    }
                case VehicleType.CAMION:
                    {
                        imageComponent.sprite = grafAntiguitatCamio;
                        currentVehicle = VehicleType.CAMION;
                        break;
                    }
            }
        }
        else
        {
            switch (vehicleType)
            {
                case VehicleType.COCHE:
                    {
                        imageComponent.sprite = grafAmbientalCoche;
                        currentVehicle = VehicleType.COCHE;
                        break;
                    }
                case VehicleType.MOTO:
                    {
                        imageComponent.sprite = grafAmbientalMoto;
                        currentVehicle = VehicleType.MOTO;
                        break;
                    }
                case VehicleType.CICLOMOTOR:
                    {
                        imageComponent.sprite = grafAmbientalCiclomotor;
                        currentVehicle = VehicleType.CICLOMOTOR;
                        break;
                    }
                case VehicleType.FURGONETA:
                    {
                        imageComponent.sprite = grafAmbientalFurgoneta;
                        currentVehicle = VehicleType.FURGONETA;
                        break;
                    }
                case VehicleType.CAMION:
                    {
                        imageComponent.sprite = grafAmbientalCamio;
                        currentVehicle = VehicleType.CAMION;
                        break;
                    }
            }
        }
        
   }
    void SwapVehicleType(bool incrementList)
    {
        if(incrementList)
        {
            currentVehicle++;
            if ((int) currentVehicle == numberOfVehicleTypes) currentVehicle = 0;            
        }
        else
        {
            currentVehicle--;
            if ((int)currentVehicle == -1) currentVehicle = (VehicleType) numberOfVehicleTypes - 1;
        }

        OpenGrafic(currentVehicle, currentGraph);
    }

    void SwapGraphType()
    {
        if (currentGraph == GraphType.ANTIGUITAT) currentGraph = GraphType.AMBIENTAL;
        else if(currentGraph == GraphType.AMBIENTAL) currentGraph = GraphType.ANTIGUITAT;

        OpenGrafic(currentVehicle, currentGraph);
    }
}
