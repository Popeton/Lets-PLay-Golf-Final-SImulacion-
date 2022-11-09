using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSystem : MonoBehaviour
{
    [SerializeField] private GameObject matrix;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BallPLayer"))
        {
            other.gameObject.GetComponent<BallController>().Stop();
            other.gameObject.GetComponent<BallController>().EnterHole();
            matrix.GetComponent<MatrixGenerator>().EnterTheHole();
            Debug.Log("Hoyo");
        }
    }
}
