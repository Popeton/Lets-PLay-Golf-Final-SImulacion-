using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PointsManager : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI  pointss;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointss.text = DataBetweenScenes.instance.points.ToString();
    }


   
}
