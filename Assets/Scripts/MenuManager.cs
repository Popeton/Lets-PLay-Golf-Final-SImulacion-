using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void Restart(int actual)
    {
        SceneManager.LoadScene(actual);
    }

    public void ClearAll()
    {
        DataBetweenScenes.instance.ClearData();
    }
}
