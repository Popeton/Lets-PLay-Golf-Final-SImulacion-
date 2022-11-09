using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    BallController ballController;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BallPLayer"))
        {
            ballController = other.GetComponent<BallController>();
            other.gameObject.transform.position = ballController.lasPosition;
            ballController.Stop();
        }
    }
}
