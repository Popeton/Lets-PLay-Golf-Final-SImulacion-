using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private int points;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BallPLayer"))
        {
            // points++;
            //points = DataBetweenScenes.instance.points;
            audioSource.PlayOneShot(clip);
            DataBetweenScenes.instance.points += points + 1;
            Destroy(gameObject);
        }
    }

    private void Update()
    {

        transform.Rotate(0, 0, 3f);
    }
}
