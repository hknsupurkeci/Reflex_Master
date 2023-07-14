using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public float spawnTime = 1;
    public float radius = 5;
    public GameObject characterPrefab;
    [SerializeField] private TextMeshProUGUI _score;

    float timer = 0f;
    float countdownDuration = 1f; // Saniye
    public static int score = 0;

    void Start()
    {
        StartCoroutine(Spawner());
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= countdownDuration)
        {
            score += 1;
            _score.text = score.ToString();
            timer = 0f;
        }
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
