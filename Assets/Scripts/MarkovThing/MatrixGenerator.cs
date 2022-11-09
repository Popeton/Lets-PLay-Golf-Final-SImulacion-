using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGenerator : MonoBehaviour
{
    public  float[,] matrix1 = new float[3,3];
    public  float[,] matrix2 = new float[3, 3];
    public float[,] matrix3 = new float[3, 3];
    void Start()
    {
        // primera matrix
        matrix1[0, 0] = 0.4f;
        matrix1[0, 1] = 0.3f;
        matrix1[0, 2] = 0.3f;
        matrix1[1, 0] = 0.2f;
        matrix1[1, 1] = 0.5f;
        matrix1[1, 2] = 0.3f;
        matrix1[2, 0] = 0.5f;
        matrix1[2, 1] = 0.5f;
        matrix1[2, 2] = 0;
        // Segunda matrix
        matrix2[0, 0] = 0.2f;
        matrix2[0, 1] = 0.5f;
        matrix2[0, 2] = 0.3f;
        matrix2[1, 0] = 0.5f;
        matrix2[1, 1] = 0.4f;
        matrix2[1, 2] = 0.1f;
        matrix2[2, 0] = 0f;
        matrix2[2, 1] = 0.4f;
        matrix2[2, 2] = 0.6f;
        // tercera matrix
        matrix3[0, 0] = 0.9f;
        matrix3[0, 1] = 0.1f;
        matrix3[0, 2] = 0;
        matrix3[1, 0] = 0.2f;
        matrix3[1, 1] = 0.6f;
        matrix3[1, 2] = 0.2f;
        matrix3[2, 0] = 0.3f;
        matrix3[2, 1] = 0.3f;
        matrix3[2, 2] = 0.4f;
        //for (int i = 0; i < matrix.GetLength(0); i++)
        //{

        //    for(var j = 0; j < matrix.GetLength(1); j++)
        //    {
        //        matrix[i, j] = Random.Range(0f, 1f); 

        //    }
        //}

        for (int i = 0; i < matrix2.GetLength(0); i++)
        {
            for (var j = 0; j < matrix2.GetLength(1); j++)
            {
                print(i + "," + j + " = " + matrix2[i, j]);

            }
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
