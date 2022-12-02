using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeManager : MonoBehaviour
{
    public GameObject other;
    private ParticleSystem system;

    private void Start()
    {
        system = other.GetComponent<ParticleSystem>();
    }




    private void FixedUpdate()
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(Camera.main.transform.position, 
            Camera.main.transform.forward, 
            out raycastHit, Mathf.Infinity))
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * raycastHit.distance, Color.yellow);
            //Debug.Log("Raycast hit: " + raycastHit.transform.name);
            Debug.Log("Raycast Pos: " + raycastHit.transform.position);

        } else
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * raycastHit.distance, Color.white);
        }

        ParticleSystem.ShapeModule _editableShape = system.shape;
        _editableShape.position = Camera.main.transform.forward;
        Debug.Log("MainCamera Pos: " + Camera.main.transform.position);
        Debug.Log("MainCamera For: " + Camera.main.transform.forward);
    }
}
