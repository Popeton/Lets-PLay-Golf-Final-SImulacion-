using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineVisual;
    [SerializeField] private int _lineCount;

    private List<Vector3> linePoints = new List<Vector3>();

    public static Projection Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateTrajectory(Vector3 force, Rigidbody rb, Vector3 inicialPos)
    {
        Vector3 velocity = (force / rb.mass) * Time.fixedDeltaTime; //segunda ley de newton f=m*a... sabiendo que a = v/t entonces v = f*t/m

        float durationOnAir = (2 * velocity.y) / Physics.gravity.y;// lo usamos para hallar el rango de tiempo en el aire 

        float stepTime = durationOnAir / _lineCount;// se calcula los puntos en la trayectoria 

        linePoints.Clear();

        for (int i = 0; i < _lineCount; i++)
        {
            float changeinTime = stepTime * i;

            // calculamos  la posicion y la velocidad en cada punto y tenemos en cuneta la gravedad en la Y 
            Vector3 movement = new Vector3(velocity.x * changeinTime, 
                                           velocity.y * changeinTime - 0.5f * Physics.gravity.y * changeinTime * changeinTime,
                                           velocity.z * changeinTime);

            linePoints.Add(-movement + inicialPos);   

            
        }

        _lineVisual.positionCount = linePoints.Count;
        _lineVisual.SetPositions(linePoints.ToArray());
    } 

    public void HideTrajectory()
    {
        _lineVisual.positionCount = 0;
    }

}
