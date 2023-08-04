using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
    EdgeCollider2D edgeCollider;

    List<GameObject> circles = new List<GameObject>();
    private List<Vector2> points = new();

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider.transform.position -= transform.position;
    }

    // Method to set a new position for the line
    public void SetPosition(Vector2 pos)
    {
        if (!CanDraw(pos))
            return;

        points.Add(pos);

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);

        edgeCollider.points = points.ToArray();
    }

    // Check if a new point can be added based on the resolution specified in the DrawManager
    private bool CanDraw(Vector2 pos)
    {
        if (lineRenderer.positionCount == 0)
        {
            return true;
        }

        Vector2 lastPos = lineRenderer.GetPosition(lineRenderer.positionCount - 1);

        // Check if the distance between the last position and the new position is greater than the specified resolution
        return Vector2.Distance(lastPos, pos) > DrawManager.RESOLUTION;
    }
}
