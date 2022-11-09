using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSystem : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BallPLayer"))
        {
            other.gameObject.GetComponent<BallController>().Stop();
            other.gameObject.GetComponent<BallController>().EnterHole();
            Debug.Log("Hoyo");
        }
    }
}
