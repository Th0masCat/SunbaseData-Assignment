using UnityEngine;
using DG.Tweening;

public class CircleSpriteBehaviour : MonoBehaviour
{
    bool markedForDeletion = false; // Flag to indicate if the sprite is marked for deletion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Line"))
        {
            markedForDeletion = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void Update()
    {
        // Check if the sprite is marked for deletion and the mouse button is released
        if (markedForDeletion && Input.GetMouseButtonUp(0))
        {
            // Animate the scaling of the sprite to zero over a duration of 0.5 seconds
            // When the animation is complete, deactivate the gameObject
            transform.DOScale(0f, 0.5f).OnComplete(() => gameObject.SetActive(false));
            markedForDeletion = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
