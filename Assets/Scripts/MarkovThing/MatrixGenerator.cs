using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGenerator : MonoBehaviour
{
    private float[,] matrix = new float[3,3];
    void Start()
    {
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            
            for(var j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = Random.Range(0f, 1f); 
                
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
               print(i +","+ j + " = " + matrix[i, j]);

            }
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
