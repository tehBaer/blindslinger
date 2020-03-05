using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public int rotationsPerMinute;
    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        RotateAxis();
        DrawTrajectory(.5f, .02f);
    }

    public void RotateAxis()
    {        
        // Change the direction of the continous rotation 
        int x = Random.Range(0, 360);
        gameObject.transform.rotation = Quaternion.Euler(x, 0, 0);
    }

    // Draw red circle for the path of the Bubble
    public void DrawTrajectory(float radius, float lineWidth)
    {
        var segments = 360;
        var line = gameObject.GetComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.positionCount = segments + 1;
        
        // Add an extra point to make startpoint and endpoint the same (to close the circle)
        var pointCount = segments + 1; 
        var points = new Vector3[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius, 0, Mathf.Cos(rad) * radius);
        }
        line.SetPositions(points);
    }

    void Update()
    {
        // Set continous rotation
        gameObject.transform.Rotate(0, 6 * rotationsPerMinute * Time.deltaTime, 0);
    }
}
