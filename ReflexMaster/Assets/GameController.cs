using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float spawnTime = 1;
    public float radius = 5;
    public GameObject characterPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }
    
    IEnumerator Spawner()
    {
        while (true)
        {
            // Hedefin etrafýnda rastgele bir konum seç
            Vector2 randomPoint = Random.insideUnitCircle.normalized * radius;
            Vector2 spawnPosition = Vector2.zero + new Vector2(randomPoint.x,randomPoint.y);

            // Karakteri oluþtur
            Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
