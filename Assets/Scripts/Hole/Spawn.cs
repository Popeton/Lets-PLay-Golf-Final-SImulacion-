using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
   [SerializeField] private GameObject[] spawnGameObject;
    private int i;
    void Start()
    {
        i = Random.Range(1, 3);

        if(i == 1)
        {
            spawnGameObject[0].SetActive(true);
        }
        else
        {
            spawnGameObject[1].SetActive(true);

        }


    }



    
}
