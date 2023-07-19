using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public float spawnTime = 1;
    public float radius = 5;
    public List<GameObject> enemyPrefabs;
    public GameObject enemysPrefObj;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private List<GameObject> gameModes;

    float timer = 0f;
    float countdownDuration = 1f; // Saniye
    public static int score = 0;

    public static SpriteRenderer[] spriteRenderers;
    public float colorChangeDuration = 2f;

    private Color startColor;
    private Color endColor;
    private float t = 0f;

    void Start()
    {
        startColor = spriteRenderers[0].color;
        endColor = new Color(Random.value, Random.value, Random.value, startColor.a);
    }

    private void Update()
    {
        t += Time.deltaTime / colorChangeDuration;
        if (t > 1f)
        {
            t = 0f;
            startColor = spriteRenderers[0].color;
            endColor = new Color(Random.value, Random.value, Random.value, startColor.a);
        }

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            Color lerpedColor = Color.Lerp(startColor, endColor, t);
            spriteRenderers[i].color = lerpedColor;
        }
        float currentFPS = 1.0f / Time.deltaTime;
        fps.text = "Fps : " + currentFPS.ToString();
    }
    public TextMeshProUGUI fps;
    private void FixedUpdate()
    {
        if (UIController.isStart)
        {
            timer += Time.deltaTime;
            if (timer >= countdownDuration)
            {
                score += 1;
                _score.text = score.ToString();
                timer = 0f;
            }
        }
    }
    public IEnumerator Spawner()
    {
        bool flag = false;
        int counter = 0;
        while (true)
        {
            if (!flag)
            {
                int rand = Random.Range(0, 15);
                if (rand == 2)
                {
                    flag = true;
                    counter = 9;
                }
                // Hedefin etrafýnda rastgele bir konum seç
                Vector2 randomPoint = Random.insideUnitCircle.normalized * radius;
                Vector2 spawnPosition = Vector2.zero + new Vector2(randomPoint.x, randomPoint.y);
                // Karakteri oluþtur - UIController.selectedGame uicontrollerden gelen seçili oyun modu id si
                GameObject enemy = Instantiate(enemyPrefabs[UIController.selectedGame], spawnPosition, Quaternion.identity);
                enemy.transform.SetParent(enemysPrefObj.transform);
            }
            else
            {
                if(counter%3==0)
                    CircleSpawner(Random.Range(10, 15), radius);
                counter--;
                if (counter == 0)
                    flag = false;
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void CircleSpawner(int spawnCount, float radius)
    {
        float angleIncrement = 360f / spawnCount;

        for (int i = 0; i < spawnCount; i++)
        {
            float angle = i * angleIncrement;
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
            float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

            Vector2 spawnPosition = new Vector2(transform.position.x + x, transform.position.y + y);
            GameObject enemy = Instantiate(enemyPrefabs[UIController.selectedGame], spawnPosition, Quaternion.identity);
            enemy.transform.SetParent(enemysPrefObj.transform);
        }
    }
}
