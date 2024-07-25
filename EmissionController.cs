using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionController : MonoBehaviour
{
    [Header("MATERIALS WILL BE PULLED AUTOMATICALLY")]
    [Tooltip("Check if the material is correct")]
    [SerializeField] Material emissiveMaterial;
    [Tooltip("Check if the renderer is correct")]
    [SerializeField] Renderer emissiveRenderer;

    private void Awake()
    {
        // If emissiveRenderer is not assigned in the Inspector, find it automatically
        if (emissiveRenderer == null)
        {
            emissiveRenderer = GetComponent<Renderer>();
        }

        // If the material is not assigned in the Inspector, get it from the renderer
        if (emissiveRenderer != null && emissiveMaterial == null)
        {
            emissiveMaterial = emissiveRenderer.material;
        }
    }

    private void Start()
    {
        //This is essential for controlling emissions
        emissiveMaterial = emissiveRenderer.GetComponent<Renderer>().material;
    }

    //Turn Off the emission
    public void TurnEmissionOff() //Turn Off the emission, call this from any object you wish (example: Trigger)
    {
        //The keyword "_EMISSION" is built-in inside the shader details
        this.emissiveMaterial.DisableKeyword("_EMISSION");
    }

    //Turn On the emission
    public void TurnEmissionOn() //Turn On the emission, call this from any object you wish (example: Fusebox)
    {
        //The keyword "_EMISSION" is built-in inside the shader details
        this.emissiveMaterial.EnableKeyword("_EMISSION");
    }


}
