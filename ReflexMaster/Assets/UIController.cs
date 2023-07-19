using System.Collections;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameController GameController;

    public GameObject triangleObjectGame;
    public GameObject squareObjectGame;
    public GameObject hexagonObjectGame;

    private Vector3[] positions = new Vector3[3];
    private int currentIndex = 0;

    public static int selectedGame; //triangle=0, hexagon=1, square=2
    public static bool isStart = false;
    public static Coroutine startCor;

    private void Start()
    {
        GameController.spriteRenderers = triangleObjectGame.GetComponentsInChildren<SpriteRenderer>();
        positions[0] = UIObjects._triangleObject.transform.position;
        positions[1] = UIObjects._squareObject.transform.position;
        positions[2] = UIObjects._hexagonObject.transform.position;
    }

    public void OnLeftButtonClick()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = positions.Length - 1;

        SwitchToCurrentIndex();
    }

    public void OnRightButtonClick()
    {
        currentIndex++;
        if (currentIndex >= positions.Length)
            currentIndex = 0;

        SwitchToCurrentIndex();
    }

    private void SwitchToCurrentIndex()
    {
        selectedGame = currentIndex;

        switch (selectedGame)
        {
            case 0:
                GameController.spriteRenderers = triangleObjectGame.GetComponentsInChildren<SpriteRenderer>();
                triangleObjectGame.SetActive(true);
                squareObjectGame.SetActive(false);
                hexagonObjectGame.SetActive(false);
                break;
            case 1:
                GameController.spriteRenderers = hexagonObjectGame.GetComponentsInChildren<SpriteRenderer>();
                triangleObjectGame.SetActive(false);
                squareObjectGame.SetActive(false);
                hexagonObjectGame.SetActive(true);
                break;
            case 2:
                GameController.spriteRenderers = squareObjectGame.GetComponentsInChildren<SpriteRenderer>();
                triangleObjectGame.SetActive(false);
                squareObjectGame.SetActive(true);
                hexagonObjectGame.SetActive(false);
                break;
        }
        Vector3 targetPosition = positions[currentIndex];

        // Triangle, Square ve Hexagon objeleri doðru konuma lerp ile kaydýrýlýyor
        StartCoroutine(MoveObjectWithLerp(UIObjects._triangleObject, targetPosition));

        int nextIndex = (currentIndex + 1) % positions.Length;
        StartCoroutine(MoveObjectWithLerp(UIObjects._squareObject, positions[nextIndex]));

        int prevIndex = (currentIndex - 1 + positions.Length) % positions.Length;
        StartCoroutine(MoveObjectWithLerp(UIObjects._hexagonObject, positions[prevIndex]));

    }

    private IEnumerator MoveObjectWithLerp(GameObject obj, Vector3 targetPosition)
    {
        float duration = 0.5f;
        float elapsedTime = 0f;
        Vector3 startPosition = obj.transform.position;

        while (elapsedTime < duration)
        {
            obj.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = targetPosition;
    }

    public void StartGame()
    {
        UIObjects.StartCombination();
        flagStartCount = true;
    }

    bool flagStartCount = false;
    float timer = 0;
    float countdownDuration = 1f;
    int count = 3;
    private void Update()
    {
        if(flagStartCount)
        {
            timer += Time.deltaTime;
            if (timer >= countdownDuration)
            {
                count--;
                if(count == 0)
                {
                    flagStartCount = false;
                    count = 3;
                    isStart = true;
                    UIObjects._startCounter.SetActive(false);
                    UIObjects._startCounterText.text = "3";
                    startCor = StartCoroutine(GameController.Spawner());
                }
                else
                    UIObjects._startCounterText.text = count.ToString();
                timer = 0f;
            }
        }
    }
}
