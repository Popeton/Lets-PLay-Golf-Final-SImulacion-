using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    Camera mainCamera;

    [Header("Ball Settings")]
    [SerializeField] private float stopVelocity;
    [SerializeField] private float shotPower;

    bool isAiming;  
    bool isIdle;  
    bool isShooting;

    Vector3 worldPoint;
    Vector3 mousePressDownPos;
    Vector3 mouseReleasePos;
    void Awake()
    {
        mainCamera = Camera.main;
        rb.maxAngularVelocity = 100f;
        isAiming = false;
    }

    
    void Update()
    {
        print(rb.velocity.magnitude);
        if(rb.velocity.magnitude < stopVelocity)
        {
            ProcessAim();

            if (Input.GetMouseButtonDown(0))
            {
               if (isIdle) isAiming = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isShooting = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

     void FixedUpdate()
     {
        if(rb.velocity.magnitude < stopVelocity)
        {
            Stop();
        }

        //if (isShooting)
        //{
        //    //Shoot(worldPoint);
        //    isShooting = false; 
        //}
     }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        if (isShooting)
        {
            mouseReleasePos = Input.mousePosition;
            Shoot(mousePressDownPos - mouseReleasePos);
            isShooting = false;
        }
    }
    private void ProcessAim()
    {
        if (!isAiming && !isIdle) return;

        worldPoint = CastMouseClickRay();
    }

    private Vector3 CastMouseClickRay()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo)) return hitInfo.point;
        else return Vector3.zero; 
    }

    private void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        isIdle = true;
    }

    private void Shoot(Vector3 vector)
    {
        isAiming = false;

        Vector3 horizontalWorldPos = new Vector3(vector.x, transform.position.y, vector.z);

        Vector3 direction = (horizontalWorldPos - transform.position).normalized;

        float force = Vector3.Distance(transform.position, horizontalWorldPos);
        rb.AddForce((direction * force) * shotPower);
        // rb.AddForce(new Vector3(vector.x, transform.position.y, vector.y) * shotPower);

    }
}
