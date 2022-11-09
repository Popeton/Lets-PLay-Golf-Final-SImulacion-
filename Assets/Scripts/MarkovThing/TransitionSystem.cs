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
   

    public void Transition( int currentPlanet, int nextPlanet)
    {
        NewPlanet = currentPlanet;

        //if(nextPlanet == 1)
        //{
        //    tierra = 1;
        //}
        
        //if (nextPlanet == 2)
        //{
        //    marte = 2;
        //}
        
        //if (nextPlanet == 3)
        //{
        //    jupiter = 3;
        //}

        m_trans1.text = NewPlanet.ToString();
        m_trans11.text = nextPlanet.ToString();

        print(NewPlanet);
        print(nextPlanet);
    }
}
