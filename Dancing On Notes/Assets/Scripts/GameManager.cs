using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MomentumController _MomentumController;
    [SerializeField] private TextMeshProUGUI _score;
    private int _currentScore;
    [SerializeField] private int _points = 100;
    [SerializeField] private GameObject _restartUI;
    [SerializeField] private PlatformController _platform;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _platformObject;

    private void Start()
    {
        _currentScore = Int32.Parse(_score.text);
    }

    private void Update()
    {
        if (_MomentumController.GetMomentum() == 0)
        {
            Finish();
        }

        _animator.SetFloat("mom", _MomentumController.GetMomentum());
    }

    public void Score()
    {
        _currentScore += _points + (int)(_points * _MomentumController.GetMomentum() / 1000);
        _score.text = _currentScore.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("TestLevel");
    }

    public void Finish()
    {
        _restartUI.SetActive(true);
        _platformObject.SetActive(false);
        _player.GetComponent<PlayerController>().enabled = false;
    }
}
