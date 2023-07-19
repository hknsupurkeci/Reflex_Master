using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterObject : MonoBehaviour
{
    public GameObject enemysPrefObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(UIController.startCor != null && collision.tag == "enemy")
        {
            UIController.isStart = false;
            StopCoroutine(UIController.startCor);
            foreach (Transform child in enemysPrefObj.transform)
            {
                Destroy(child.gameObject);
            }

            //UI
            UIObjects.GameOverCombination();
            switch (UIController.selectedGame)
            {
                case 0:
                    if (GameController.score > PlayerPrefs.GetInt("triangleMax"))
                    {
                        UIObjects._triangleMaxScore.text = GameController.score.ToString();
                        PlayerPrefs.SetInt("triangleMax", GameController.score);
                    }
                    break;
                case 1:
                    if(GameController.score > PlayerPrefs.GetInt("hexagonMax"))
                    {
                        UIObjects._hexagonMaxScore.text = GameController.score.ToString();
                        PlayerPrefs.SetInt("hexagonMax", GameController.score);
                    }
                    break;
                case 2:
                    if(GameController.score > PlayerPrefs.GetInt("squareMax"))
                    {
                        UIObjects._squareMaxScore.text = GameController.score.ToString();
                        PlayerPrefs.SetInt("squareMax", GameController.score);
                    }
                    break;
                default:
                    break;
            }
            GameController.score = 0;
            UIObjects._scoreInGame.text = "0";
        }
    }
}
