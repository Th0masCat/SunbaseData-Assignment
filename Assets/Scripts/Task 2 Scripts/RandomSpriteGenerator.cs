using UnityEngine;

public class RandomSpriteGenerator : MonoBehaviour
{
    public GameObject spritePrefab;
    public Camera mainCamera;

    public void GenerateRandomSprite()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 10f);
        //
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        GameObject newSprite = Instantiate(spritePrefab, randomPosition, randomRotation);
        newSprite.transform.SetParent(mainCamera.transform);
    }
}
