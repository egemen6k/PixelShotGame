using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private GameObject _playerObj;

    private BallMovement _player;
    private int _points;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: 0";

        _player = GameObject.Find("Player").GetComponent<BallMovement>();
    }

    public void UpdateScore()
    {
        _points++;
        _scoreText.text = "Score: " + _points;
    }

    //public void RestartGame()
    //{
    //    _player.RestartGame();
    //}

    public void NewBall()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Instantiate(_playerObj, new Vector3(0, -4, 0), Quaternion.identity);      
    }
}
