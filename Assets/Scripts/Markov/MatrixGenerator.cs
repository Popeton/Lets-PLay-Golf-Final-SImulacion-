
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatrixGenerator : MonoBehaviour
{
    //matrices
    private float[,] matrix1 = new float[3,3];
    private float[,] matrix2 = new float[3, 3];
    private float[,] matrix3 = new float[3, 3];
    private float[,] matrixEscogida = new float[3,3];

    private  float t,a;
    private  int id,count;
    

    [SerializeField] private string planetaActual;
    [SerializeField] private int currentPlanet;
    [SerializeField] private GameObject[] loadmessage;

    private void Start()
    {
        count = DataBetweenScenes.instance.count;
        if(count != 1)
        {
            ChooseMatrix();
            count++;
            print(count);
            DataBetweenScenes.instance.count = count;
        }
    }


   
    public void EnterTheHole()
    {
        
        ActualPlanet(planetaActual);
    }
    private void ChooseMatrix()
    {
        // primera matrix
        //tierra
        matrix1[0, 0] = 0.4f;
        matrix1[0, 1] = 0.3f;
        matrix1[0, 2] = 0.3f;
        //marte
        matrix1[1, 0] = 0.2f;
        matrix1[1, 1] = 0.5f;
        matrix1[1, 2] = 0.3f;
        //jupiter
        matrix1[2, 0] = 0.5f;
        matrix1[2, 1] = 0.5f;
        matrix1[2, 2] = 0;

        // Segunda matrix
        //tierra
        matrix2[0, 0] = 0.2f;
        matrix2[0, 1] = 0.5f;
        matrix2[0, 2] = 0.3f;
        //marte
        matrix2[1, 0] = 0.5f;
        matrix2[1, 1] = 0.4f;
        matrix2[1, 2] = 0.1f;
        //jupiter
        matrix2[2, 0] = 0f;
        matrix2[2, 1] = 0.4f;
        matrix2[2, 2] = 0.6f;

        // tercera matrix
        //tierra
        matrix3[0, 0] = 0.9f;
        matrix3[0, 1] = 0.1f;
        matrix3[0, 2] = 0;
        //marte
        matrix3[1, 0] = 0.2f;
        matrix3[1, 1] = 0.6f;
        matrix3[1, 2] = 0.2f;
        //jupiter
        matrix3[2, 0] = 0.3f;
        matrix3[2, 1] = 0.3f;
        matrix3[2, 2] = 0.4f;

        id = Random.Range(1, 4);
        print("matrix" + id);

        if (id == 1)
        {
            matrixEscogida = matrix1;
            DataBetweenScenes.instance.SetMatrix(matrix1);
        }
        if (id == 2)
        {
            matrixEscogida = matrix2;
            DataBetweenScenes.instance.SetMatrix(matrix2);

        }
        if (id == 3)
        {
            matrixEscogida = matrix3;
            DataBetweenScenes.instance.SetMatrix(matrix3);

        }
    }
    private void ActualPlanet(string planeta)
    {

        

        if (planeta == "tierra" )
        {
            ChangeScenes(0);
            DataBetweenScenes.instance.earth++;
            DataBetweenScenes.instance.checkTierra = true;
        }
        
        else if (planeta == "marte" )

        {
            ChangeScenes(1);
            DataBetweenScenes.instance.earth++;
            DataBetweenScenes.instance.checkMarte = true;

        }
        else if (planeta == "jupiter" )
        {
            ChangeScenes(2);
            DataBetweenScenes.instance.earth++;
            DataBetweenScenes.instance.cheekJupiter = true;

        }
        
        if (DataBetweenScenes.instance.earth>3)
        {
            SceneManager.LoadScene(4);
        }
    }
   
    private void ChangeScenes(int i)
    {
        matrixEscogida = DataBetweenScenes.instance.GetMatrix();
        t = Random.Range(0, 1f);
        a = matrixEscogida[i, 0] + matrixEscogida[i, 1];
        
       
      

        if (t <= matrixEscogida[i, 0])
        {
            //LoadingScene(1);
            SceneManager.LoadScene(1);
            DataBetweenScenes.instance.SetNextPlanet(1);
            DataBetweenScenes.instance.SetCurrentPlanet(currentPlanet);
            DataBetweenScenes.instance.prob.Add (matrixEscogida[i, 0]);
            print(matrixEscogida[i, 0]);
            print("primero");
        }
        if (t > matrixEscogida[i, 0] && t <= a)
        {
            //LoadingScene(2);
            SceneManager.LoadScene(2);
            DataBetweenScenes.instance.SetNextPlanet(2);
            DataBetweenScenes.instance.SetCurrentPlanet(currentPlanet);
            DataBetweenScenes.instance.prob.Add(matrixEscogida[i, 1]);
            print(matrixEscogida[i, 1]);

            print("segundo");
        }

        if (t > a && t < 1)
        {
            //LoadingScene(3);
            SceneManager.LoadScene(3);
            DataBetweenScenes.instance.SetNextPlanet(3);
            DataBetweenScenes.instance.SetCurrentPlanet(currentPlanet);
            DataBetweenScenes.instance.prob.Add(matrixEscogida[i, 2]);
            print(matrixEscogida[i, 2]);
            print("tercero");
        }
    }


    public void LoadingScene(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadmessage[index - 1].gameObject.SetActive(true);
    }

   
}
