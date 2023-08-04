using UnityEngine;

public class DrawManager : MonoBehaviour
{
    [SerializeField]
    private Line linePrefab;

    private Line currentLine;

    private Camera mainCamera;

    //The minimum distance between points when drawing
    public const float RESOLUTION = 0.1f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // When the left mouse button is pressed down
        if (Input.GetMouseButtonDown(0))
        {
            currentLine = Instantiate(linePrefab, mousePosition, Quaternion.identity); // Create a new line object
            currentLine.SetPosition(mousePosition); // Set the initial position for the line
        }

        // While the left mouse button is held down
        if (Input.GetMouseButton(0))
        {
            currentLine.SetPosition(mousePosition); // Update the position of the line
        }

        // When the left mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(currentLine.gameObject); // Destroy the line object when drawing is finished
        }
    }
}
