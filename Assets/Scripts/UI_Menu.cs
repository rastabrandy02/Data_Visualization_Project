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
    const float vehicleSlotMoveAmount = -6;
    const float vehicleSlotStartPos = -110;

    [Header("Image Components")]
    [SerializeField] Image graphImageComponent;
    [SerializeField] Image cocheImageComponent;
    [SerializeField] Image motoImageComponent;
    [SerializeField] Image ciclomotorImageComponent;
    [SerializeField] Image furgonetaImageComponent;
    [SerializeField] Image camionImageComponent;

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

    [Header("VehicleSlot")]
    [SerializeField] Sprite selectedCoche;
    [SerializeField] Sprite selectedMoto;
    [SerializeField] Sprite selectedCiclomotor;
    [SerializeField] Sprite selectedFurgoneta;
    [SerializeField] Sprite selectedCamio;
    [SerializeField] Sprite unSelectedCoche;
    [SerializeField] Sprite unSelectedMoto;
    [SerializeField] Sprite unSelectedCiclomotor;
    [SerializeField] Sprite unSelectedFurgoneta;
    [SerializeField] Sprite unSelectedCamio;


    Vector3 cocheStartLocalPos;
    Vector3 motoStartLocalPos;
    Vector3 ciclomotorStartLocalPos;
    Vector3 furgonetaStartLocalPos;
    Vector3 camionStartLocalPos;


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
        cocheStartLocalPos = cocheImageComponent.gameObject.GetComponent<RectTransform>().localPosition;
        motoStartLocalPos = motoImageComponent.gameObject.GetComponent<RectTransform>().localPosition;
        ciclomotorStartLocalPos = ciclomotorImageComponent.gameObject.GetComponent<RectTransform>().localPosition;
        furgonetaStartLocalPos = furgonetaImageComponent.gameObject.GetComponent<RectTransform>().localPosition;
        camionStartLocalPos = camionImageComponent.gameObject.GetComponent<RectTransform>().localPosition;
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
        UnSelectUIVehicleSlots();

        if (graphType == GraphType.ANTIGUITAT)
        {
            switch (vehicleType)
            {
                case VehicleType.COCHE:
                    {
                        graphImageComponent.sprite = grafAntiguitatCoche;
                        cocheImageComponent.sprite = selectedCoche;                       
                        cocheImageComponent.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0.0f, vehicleSlotMoveAmount, 0.0f);
                        currentVehicle = VehicleType.COCHE;                      
                        break;
                    }
                case VehicleType.MOTO:
                    {
                        graphImageComponent.sprite = grafAntiguitatMoto;
                        motoImageComponent.sprite = selectedMoto;
                        motoImageComponent.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0.0f, vehicleSlotMoveAmount, 0.0f);
                        currentVehicle = VehicleType.MOTO;
                        break;
                    }
                case VehicleType.CICLOMOTOR:
                    {
                        graphImageComponent.sprite = grafAntiguitatCiclomotor;
                        ciclomotorImageComponent.sprite = selectedCiclomotor;
                        ciclomotorImageComponent.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0.0f, vehicleSlotMoveAmount, 0.0f);
                        currentVehicle = VehicleType.CICLOMOTOR;
                        break;
                    }
                case VehicleType.FURGONETA:
                    {
                        graphImageComponent.sprite = grafAntiguitatFurgoneta;
                        furgonetaImageComponent.sprite = selectedFurgoneta;
                        furgonetaImageComponent.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0.0f, vehicleSlotMoveAmount, 0.0f);
                        currentVehicle = VehicleType.FURGONETA;
                        break;
                    }
                case VehicleType.CAMION:
                    {
                        camionImageComponent.sprite = selectedCamio;
                        graphImageComponent.sprite = grafAntiguitatCamio;
                        camionImageComponent.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0.0f, vehicleSlotMoveAmount, 0.0f);
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
                        graphImageComponent.sprite = grafAmbientalCoche;
                        cocheImageComponent.sprite = selectedCoche;
                        cocheImageComponent.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0.0f, vehicleSlotMoveAmount, 0.0f);
                        currentVehicle = VehicleType.COCHE;
                        break;
                    }
                case VehicleType.MOTO:
                    {
                        graphImageComponent.sprite = grafAmbientalMoto;
                        motoImageComponent.sprite = selectedMoto;
                        motoImageComponent.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0.0f, vehicleSlotMoveAmount, 0.0f);
                        currentVehicle = VehicleType.MOTO;
                        break;
                    }
                case VehicleType.CICLOMOTOR:
                    {
                        graphImageComponent.sprite = grafAmbientalCiclomotor;
                        ciclomotorImageComponent.sprite = selectedCiclomotor;
                        ciclomotorImageComponent.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0.0f, vehicleSlotMoveAmount, 0.0f);
                        currentVehicle = VehicleType.CICLOMOTOR;
                        break;
                    }
                case VehicleType.FURGONETA:
                    {
                        graphImageComponent.sprite = grafAmbientalFurgoneta;
                        furgonetaImageComponent.sprite = selectedFurgoneta;
                        furgonetaImageComponent.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0.0f, vehicleSlotMoveAmount, 0.0f);
                        currentVehicle = VehicleType.FURGONETA;
                        break;
                    }
                case VehicleType.CAMION:
                    {
                        graphImageComponent.sprite = grafAmbientalCamio;                        
                        camionImageComponent.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0.0f, vehicleSlotMoveAmount, 0.0f);
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

    void UnSelectUIVehicleSlots()
    {
        cocheImageComponent.sprite = unSelectedCoche;
        motoImageComponent.sprite = unSelectedMoto;
        ciclomotorImageComponent.sprite = unSelectedCiclomotor;
        furgonetaImageComponent.sprite = unSelectedFurgoneta;
        camionImageComponent.sprite = unSelectedCamio;

        cocheImageComponent.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(cocheImageComponent.gameObject.GetComponent<RectTransform>().localPosition.x, vehicleSlotStartPos, 0.0f);
        motoImageComponent.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(motoImageComponent.gameObject.GetComponent<RectTransform>().localPosition.x, vehicleSlotStartPos, 0.0f);
        ciclomotorImageComponent.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(ciclomotorImageComponent.gameObject.GetComponent<RectTransform>().localPosition.x, vehicleSlotStartPos, 0.0f);
        furgonetaImageComponent.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(furgonetaImageComponent.gameObject.GetComponent<RectTransform>().localPosition.x, vehicleSlotStartPos, 0.0f);
        camionImageComponent.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(camionImageComponent.gameObject.GetComponent<RectTransform>().localPosition.x, vehicleSlotStartPos, 0.0f);
        
    }
}
