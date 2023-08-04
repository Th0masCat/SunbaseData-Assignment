using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawManager : MonoBehaviour
{
    private Camera mainCamera;
    private LineRenderer lineRenderer;

    [SerializeField]
    private Line linePrefab;

    private Line currentLine;

    public const float RESOLUTION = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            currentLine = Instantiate(linePrefab, mousePosition, Quaternion.identity);
            currentLine.SetPosition(mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            currentLine.SetPosition(mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Destroy(currentLine.gameObject);
        }
    }
}
