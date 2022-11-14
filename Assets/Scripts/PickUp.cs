using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private int points;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BallPLayer"))
        {
           // points++;
           //points = DataBetweenScenes.instance.points;
            DataBetweenScenes.instance.points += points +1;
            Destroy(gameObject);
        }
    }

    private void Update()
    {

        transform.Rotate(0, 0, 5f);
    }
}
