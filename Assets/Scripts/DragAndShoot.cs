using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragAndShoot : MonoBehaviour
{
    Vector3 mousePressDownPos;
    Vector3 mouseReleasePos;

    float forceMultiplier = 3;

    Rigidbody rb;

    bool isShoot;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }
    private void OnMouseDrag()
    {
        Vector3 initForce = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = (new Vector3(initForce.x,initForce.y,initForce.y)) * forceMultiplier;

        if (!isShoot) Projection.Instance.UpdateTrajectory(forceV, rb, transform.position); 
    }

    private void OnMouseUp()
    {
        Projection.Instance.HideTrajectory();
        mouseReleasePos= Input.mousePosition;
        Shoot(mousePressDownPos - mouseReleasePos);
    }
    
    void Shoot(Vector3 force)
    {
        if (isShoot) return;
        rb.AddForce(new Vector3(force.x, force.y, force.y) * forceMultiplier);
        isShoot = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
