using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilations : MonoBehaviour
{
    [SerializeField] private float amplitude = 1;
    [SerializeField] private float period = 1;
    [SerializeField] private float typeOfObstacule;
    float initialRotation;
    Vector3 initialPosition;

    private void Start()
    {
        if(typeOfObstacule==0) typeOfObstacule = 1;
        initialPosition = transform.position;
        initialRotation = transform.localRotation.y;
    }
    void Update()
    {
        if(typeOfObstacule == 1)
        {
            float x = amplitude * Mathf.Sin(2 * Mathf.PI * (Time.time / period));
            transform.position = initialPosition + new Vector3(x, 0,0 );
        }

        // transform.Rotate(0, 5, 0);


        if (typeOfObstacule == 2)
        {
            float y = amplitude * Mathf.Sin(4 * Mathf.PI * (Time.time / period));
            transform.Rotate(0, initialRotation + y, 0);

        }

    }
}
