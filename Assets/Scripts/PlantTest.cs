using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTest : MonoBehaviour
{
    public GameObject pottedPlant;
    public Transform spawnPoint;


    public void PottedPlant()
    {
        GameObject plant = GameObject.Instantiate(pottedPlant);
        plant.transform.position = spawnPoint.position;
    }
}
