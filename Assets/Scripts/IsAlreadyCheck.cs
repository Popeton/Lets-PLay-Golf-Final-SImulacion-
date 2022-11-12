using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsAlreadyCheck : MonoBehaviour
{
   


    private void Start()
    {
        if(DataBetweenScenes.instance.checkTierra == true && DataBetweenScenes.instance.cheekJupiter == true && DataBetweenScenes.instance.checkMarte == true)
        {
            SceneManager.LoadScene(3);
        }
    }
}
