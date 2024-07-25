using System.Collections;
using System.Collections.Generic;
using UHFPS.Runtime;
using UnityEngine;

public class LightsOut : MonoBehaviour
{

    [Header("ASSIGNMENTS")]
    [Tooltip("These are the Light GameObjects you need to be disabled")]
    [SerializeField] private List<GameObject> roomLights;

    [Header("THESE WILL BE PULLED AUTOMATICALLY")]
    [Tooltip("You can check if the assigned objects are correctly set in the List")]
    [SerializeField] private List<EmissionController> emissionControllerScripts; //Objects that emission controller script has been attached to

    private void Awake()
    {
        // Find all EmissionController scripts in the scene and store them in the emissionControllerScripts list
        emissionControllerScripts = new List<EmissionController>(FindObjectsOfType<EmissionController>());
    }


    private void OnTriggerEnter(Collider other)
    {
        //Play electricity outage sound here

        //Turn the emission off in all the objects that the Emission Controller Script is attached to
        foreach (var emissionController in emissionControllerScripts)
        {
            emissionController.TurnEmissionOff();
        }

        //Disable all the lights that is in the list
        foreach (GameObject light in roomLights)
        {
            light.SetActive(false);
        }

        //Afterwards disable this object
        this.gameObject.SetActive(false);
    }

    


}
