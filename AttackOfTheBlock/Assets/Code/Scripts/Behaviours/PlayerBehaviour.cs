using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int playerMaxLives;
    public GameObject gameManager;
    public float inmunityTime;

    private bool _isPlayerInInmunityEffect;
    private Animator _animator;
    private float _time2FinishInmunity;
    private AudioSource _audioSource;
    private int _playerActualLives;

    public int playerActualLives
    {
        get => _playerActualLives;
    }

    private void Start()
    {
        _playerActualLives = playerMaxLives;
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        setLivesToUI();
    }

    void Update()
    {
        if (this._isPlayerInInmunityEffect && this._time2FinishInmunity < Time.time)
        {
            changeInmunityToPlayer(false);
        }
        if (_playerActualLives <= 0 && !_audioSource.isPlaying )
        {
            gameManager.GetComponent<GameManager>().finishGame();
        }
    }

    private void setLivesToUI()
    {
        gameManager.GetComponent<UIManager>().generateHearts(playerMaxLives);
    }


    private void reducePlayerLive()
    {
        _playerActualLives--;
        gameManager.GetComponent<UIManager>().fillInOutheart(_playerActualLives, false);
        if (_playerActualLives <= 0)
        {
            _audioSource.Play();
        }
    }

    public void hitPlayer()
    {
        if (!this._isPlayerInInmunityEffect)
        {
            this._time2FinishInmunity = Time.time + inmunityTime;
            changeInmunityToPlayer(true);
            reducePlayerLive();
        }
    }

    public void getOneMoreLive()
    {
        if (_playerActualLives<playerMaxLives)
        {
            _playerActualLives++;
            gameManager.GetComponent<UIManager>().fillInOutheart(_playerActualLives-1, true);
        }
    }

    private void changeInmunityToPlayer(bool isInmunity)
    {
        this._isPlayerInInmunityEffect = isInmunity;
        _animator.SetBool("isHitted", isInmunity);
    }
}
