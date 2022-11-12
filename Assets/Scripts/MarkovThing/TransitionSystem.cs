using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransitionSystem : MonoBehaviour
{
   // int currentPlanet;
    public int NewPlanet;
    public int tierra, marte, jupiter;

    [SerializeField] private TextMeshProUGUI m_trans1, m_trans11, m_trans2, m_trans22,m_trans3, m_trans33;
    [SerializeField] private TextMeshProUGUI m_prob1, m_prob2, m_prob3;

    private void Update()
    {
        m_trans1.text = DataBetweenScenes.instance.GetCurrentPlanet(0).ToString();
        m_trans11.text = DataBetweenScenes.instance.GetNextPlanet(0).ToString();

        m_trans2.text = DataBetweenScenes.instance.GetCurrentPlanet(1).ToString();
        m_trans22.text = DataBetweenScenes.instance.GetNextPlanet(1).ToString();

        m_trans3.text = DataBetweenScenes.instance.GetCurrentPlanet(2).ToString();
        m_trans33.text = DataBetweenScenes.instance.GetNextPlanet(2).ToString();
    }

}
