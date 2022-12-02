using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeToFirework : MonoBehaviour
{
    public GameObject other;
    private ParticleSystem system;

    // Start is called before the first frame update
    void Start()
    {
        system = other.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem.ShapeModule _editableShape = system.shape;
        _editableShape.position = Camera.main.transform.position;
    }
}
