using System.Collections;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject triangleObject;
    public GameObject squareObject;
    public GameObject hexagonObject;

    public GameObject triangleObjectGame;
    public GameObject squareObjectGame;
    public GameObject hexagonObjectGame;

    private Vector3[] positions = new Vector3[3];
    private int currentIndex = 0;

    public static int selectedGame; //triangle=0, hexagon=1, square=2

    private void Start()
    {
        positions[0] = triangleObject.transform.position;
        positions[1] = squareObject.transform.position;
        positions[2] = hexagonObject.transform.position;
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
        Debug.Log(selectedGame);
        switch (selectedGame)
        {
            case 0:
                triangleObjectGame.SetActive(true);
                squareObjectGame.SetActive(false);
                hexagonObjectGame.SetActive(false);
                break;
            case 1:
                triangleObjectGame.SetActive(false);
                squareObjectGame.SetActive(false);
                hexagonObjectGame.SetActive(true);
                break;
            case 2:
                triangleObjectGame.SetActive(false);
                squareObjectGame.SetActive(true);
                hexagonObjectGame.SetActive(false);
                break;
        }
        Vector3 targetPosition = positions[currentIndex];

        // Triangle, Square ve Hexagon objeleri doðru konuma lerp ile kaydýrýlýyor
        StartCoroutine(MoveObjectWithLerp(triangleObject, targetPosition));

        int nextIndex = (currentIndex + 1) % positions.Length;
        StartCoroutine(MoveObjectWithLerp(squareObject, positions[nextIndex]));

        int prevIndex = (currentIndex - 1 + positions.Length) % positions.Length;
        StartCoroutine(MoveObjectWithLerp(hexagonObject, positions[prevIndex]));

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
}
