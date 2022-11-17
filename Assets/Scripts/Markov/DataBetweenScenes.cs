using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBetweenScenes : MonoBehaviour
{
    public static DataBetweenScenes instance;

    #region Transition Data 

    private List<int> nextPlanet = new List<int>();
    private List<int> CurrentPlanet = new List<int>();
    public List<float> prob = new List<float>();

    private float[,] matrixEscogida = new float[3, 3];


    public int count = 0, earth, points;
    public bool checkTierra, checkMarte, cheekJupiter;
    #endregion


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetNextPlanet(int i)
    {
        nextPlanet.Add(i);
    }
    public int GetNextPlanet(int index)
    {
        return nextPlanet[index];
    }

    public void SetCurrentPlanet(int j)
    {
        CurrentPlanet.Add(j);
    }
    public int GetCurrentPlanet(int index)
    {
        return CurrentPlanet[index];
    }


    public void SetMatrix(float[,] newMatrix)
    {
        matrixEscogida = newMatrix;
    }

    public float[,] GetMatrix()
    {
        return matrixEscogida;
    }

    public void ClearData()
    {
        nextPlanet.Clear();
        CurrentPlanet.Clear();
        prob.Clear();
        matrixEscogida = null;
        count = 0;
        earth = 0;
        points = 0;
        checkTierra = false;
        checkMarte = false;
        cheekJupiter = false;
    }

   
}
