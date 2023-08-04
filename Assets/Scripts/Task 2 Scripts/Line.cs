using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField]
    EdgeCollider2D edgeCollider;

    private List<Vector2> points = new List<Vector2>();

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider.transform.position -= transform.position;
    }

    public void SetPosition(Vector2 pos)
    {
        if (!CanDraw(pos))
            return;

        points.Add(pos);

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);

        edgeCollider.points = points.ToArray();
    }

    private bool CanDraw(Vector2 pos)
    {
        if (lineRenderer.positionCount == 0)
        {
            return true;
        }

        Vector2 lastPos = lineRenderer.GetPosition(lineRenderer.positionCount - 1);

        return Vector2.Distance(lastPos, pos) > DrawManager.RESOLUTION;
    }
}
