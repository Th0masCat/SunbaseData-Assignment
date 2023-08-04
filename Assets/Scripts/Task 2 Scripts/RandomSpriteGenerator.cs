using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class RandomSpriteGenerator : MonoBehaviour
{
    [SerializeField]
    List<GameObject> sprites = new List<GameObject>();

    public void Reactivate()
    {
        foreach (GameObject sprite in sprites)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(-290f, 290f),
                Random.Range(-120f, 85f)
            );
            sprite.SetActive(true);

            sprite.transform.localPosition = randomPosition;
        }
    }
}
