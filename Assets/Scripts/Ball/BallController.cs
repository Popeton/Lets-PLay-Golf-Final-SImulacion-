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
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    
    public Vector3 lasPosition;

    bool isAiming;  
    bool isIdle;  
    bool isShooting;

    Vector3? worldPoint;
    Vector3 mousePressDownPos;
    Vector3 mouseReleasePos;
    void Awake()
    {
        lineRenderer.enabled = false;
        isAiming = false;
    }

    
   

     void FixedUpdate()
     {
        if(rb.velocity.magnitude < stopVelocity)
        {
            Stop();
        }

        ProcessAim();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }


    private void OnMouseDown()
    {
        if (isIdle) isAiming = true;
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
        if (!isAiming || !isIdle) return;

        worldPoint = CastMouseClickRay();

        if (!worldPoint.HasValue) return;

        DrawnLine(worldPoint.Value);

        if (Input.GetMouseButtonUp(0)) Shoot(worldPoint.Value);
    }

    private Vector3? CastMouseClickRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit; 

        if (Physics.Raycast(worldMousePosNear,worldMousePosFar- worldMousePosNear, out  hit,float.PositiveInfinity)) return hit.point;
        else return null; 
    }

    public void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        isIdle = true;
    }

    private void Shoot(Vector3 vector)
    {
        audioSource.Play();
        lasPosition = transform.position;
        isAiming = false;
        lineRenderer.enabled = false;
        Cursor.visible = true;

        Vector3 horizontalWorldPos = new Vector3(vector.x, transform.position.y, vector.z);

        Vector3 direction = (horizontalWorldPos - transform.position).normalized;

        float force = Vector3.Distance(transform.position, horizontalWorldPos);
        rb.AddForce((direction * force) * shotPower);

        isIdle = false; 
        

    }

     private void DrawnLine(Vector3 woldpoint)
     {
        Cursor.visible = false;
        Vector3[] positions ={
            transform.position,
            woldpoint};
        lineRenderer.SetPositions(positions);
        lineRenderer.enabled = true; 

     }

    public void EnterHole()
    {
        animator.enabled = true; 
        animator.SetBool("isHole", true);
    }
}
