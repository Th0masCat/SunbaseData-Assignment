using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class RandomSpriteGenerator : MonoBehaviour
{
    [SerializeField]
    List<GameObject> sprites = new List<GameObject>();

    // Method to reactivate the sprites with random positions and scaling
    public void Reactivate()
    {
        foreach (GameObject sprite in sprites)
        {
            sprite.GetComponent<RectTransform>().localScale = Vector3.zero;
            sprite.SetActive(false);
        }

        foreach (GameObject sprite in sprites)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(-290f, 290f),
                Random.Range(-120f, 85f)
            );

            sprite.transform.localPosition = randomPosition;
            sprite.SetActive(true);
            sprite.GetComponent<CircleCollider2D>().enabled = true;
            sprite.transform.DOScale(1f, 0.5f);
        }
    }
}
