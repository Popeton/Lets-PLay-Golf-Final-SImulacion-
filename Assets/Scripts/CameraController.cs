
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset = new Vector3(-1.9f, 17.17f, -21.9f);

    private void Start()
    {
       
    }
    private void FixedUpdate()
    {
        Vector3 playerPos = player.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, playerPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothPos;

        transform.LookAt(player);
       
    }
}
