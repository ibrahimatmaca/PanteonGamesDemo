using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionPanel : MonoBehaviour
{

    [Header("Game Objects")]
    public GameObject barracks;
    public GameObject powerPlants;


    public void Barracks()
    {
        GameObject barrack = Instantiate(barracks);
        barrack.name = "barrack";
    }

    public void PowerPlant()
    {
        GameObject powerPlant = Instantiate(powerPlants);
        powerPlant.name = "powerplant";
    }

}
