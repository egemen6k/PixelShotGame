using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;

    public void NewGame()
    {

    }

    public void NewBall()
    {
        GameObject _player = GameObject.FindGameObjectWithTag("Player");
        _player.SetActive(false);
        _player.SetActive(true);
    }
}
