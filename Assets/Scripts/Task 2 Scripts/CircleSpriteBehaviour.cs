using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleSpriteBehaviour : MonoBehaviour
{
    bool markedForDeletion = false;

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
        if (markedForDeletion && Input.GetMouseButtonUp(0))
        {
            transform.DOScale(0f, 0.5f).OnComplete(() => gameObject.SetActive(false));
            markedForDeletion = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
