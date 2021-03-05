using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText, _pointsText;
    [SerializeField]
    private GameObject _playerObj;

    private int _points;

    void Start()
    {
        _scoreText.text = "Score: ";
    }

    public void UpdateScore()
    {
        _points++;
        _pointsText.text = _points.ToString();
    }

    //public void RestartGame()
    //{
    //    _player.RestartGame();
    //}

    public void NewBall()
    {
        GameObject GameManager = GameObject.FindGameObjectWithTag("GameManager");
        GameManager.GetComponent<GameManager>().NewBall();
    }

}
