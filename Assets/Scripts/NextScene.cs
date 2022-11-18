using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 

        if(timer > 15f)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
