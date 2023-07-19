using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIObjects : MonoBehaviour
{
    public GameObject triangleObject;
    public GameObject squareObject;
    public GameObject hexagonObject;

    public GameObject buttonLeft;
    public GameObject buttonRight;
    public GameObject buttonStart;

    public GameObject Score;

    public GameObject startCounter;

    public TextMeshProUGUI triangleMaxScore;
    public TextMeshProUGUI squareMaxScore;
    public TextMeshProUGUI hexagonMaxScore;
    public TextMeshProUGUI scoreInGame;

    public TextMeshProUGUI startCounterText;

    //Statics
    public static GameObject _triangleObject;
    public static GameObject _squareObject;
    public static GameObject _hexagonObject;

    public static GameObject _buttonLeft;
    public static GameObject _buttonRight;
    public static GameObject _buttonStart;

    public static GameObject _Score;

    public static GameObject _startCounter;


    public static TextMeshProUGUI _triangleMaxScore;
    public static TextMeshProUGUI _squareMaxScore;
    public static TextMeshProUGUI _hexagonMaxScore;
    public static TextMeshProUGUI _scoreInGame;

    public static TextMeshProUGUI _startCounterText;


    private void Awake()
    {
        triangleMaxScore.text = PlayerPrefs.GetInt("triangleMax", 0).ToString();
        squareMaxScore.text = PlayerPrefs.GetInt("squareMax", 0).ToString();
        hexagonMaxScore.text = PlayerPrefs.GetInt("hexagonMax", 0).ToString();
    }

    private void Start()
    {
        _triangleObject = triangleObject;
        _squareObject = squareObject;
        _hexagonObject = hexagonObject;
        _buttonLeft = buttonLeft;
        _buttonRight = buttonRight;
        _buttonStart = buttonStart;
        _Score = Score;

        _triangleMaxScore = triangleMaxScore;
        _squareMaxScore = squareMaxScore;
        _hexagonMaxScore = hexagonMaxScore;

        _scoreInGame = scoreInGame;

        _startCounter = startCounter;

        _startCounterText = startCounterText;
    }

    public static void StartCombination()
    {
        _triangleObject.SetActive(false);
        _squareObject.SetActive(false);
        _hexagonObject.SetActive(false);
        _buttonLeft.SetActive(false);
        _buttonRight.SetActive(false);
        _buttonStart.SetActive(false);
        _Score.SetActive(true);
        _startCounter.SetActive(true);
    }
    public static void GameOverCombination()
    {
        _triangleObject.SetActive(true);
        _squareObject.SetActive(true);
        _hexagonObject.SetActive(true);
        _buttonLeft.SetActive(true);
        _buttonRight.SetActive(true);
        _buttonStart.SetActive(true);
        _Score.SetActive(false);
    }
}
