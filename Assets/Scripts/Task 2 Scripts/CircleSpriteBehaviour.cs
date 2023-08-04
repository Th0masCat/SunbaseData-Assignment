using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CircleSpriteBehaviour : MonoBehaviour
{
    bool markedForDeletion = false;

    private void OnEnable()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        transform.DOScale(1f, 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Line"))
        {
            Debug.Log("Circle hit by line");
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
        }
    }
}
