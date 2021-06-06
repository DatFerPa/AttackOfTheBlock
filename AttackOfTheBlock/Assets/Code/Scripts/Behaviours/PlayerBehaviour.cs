using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Propiedades del jugador
    public int playerMaxLifes;
    public GameObject gameManager;
    public float inmunityTimeWhenHitted;
    public AudioClip soundPlayerDeath;
    public AudioClip soundPlayerHitted;

    private bool _isPlayerInInmunityEffect;
    private Animator _animator;
    private float _time2FinishInmunity;
    private AudioSource _audioSource;
    private int _playerActualLifes;
    private bool _isPLayerDeath;


    public int playerActualLives
    {
        get => _playerActualLifes;
    }

    public bool isPlayerDeath
    {
        get => _isPLayerDeath;
    }

    private void Start()
    {
        _playerActualLifes = playerMaxLifes;
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
        if (_isPLayerDeath && !_audioSource.isPlaying )
        {
            gameManager.GetComponent<GameManager>().finishGame();
        }
    }

    private void setLivesToUI()
    {
        gameManager.GetComponent<UIManager>().generateHearts(playerMaxLifes);
    }


    private void reducePlayerLife()
    {
        _playerActualLifes--;
        gameManager.GetComponent<UIManager>().fillInOutheart(_playerActualLifes, false);
        if (_playerActualLifes <= 0)
        {
            _isPLayerDeath = true;
            _audioSource.clip = soundPlayerDeath;
            _audioSource.Play();
        }
    }
    public void getOneMoreLife()
    {
        if (_playerActualLifes < playerMaxLifes)
        {
            _playerActualLifes++;
            gameManager.GetComponent<UIManager>().fillInOutheart(_playerActualLifes - 1, true);
        }
    }

    public void hitPlayer()
    {
        if (!this._isPlayerInInmunityEffect)
        {
            _audioSource.clip = soundPlayerHitted;
            _audioSource.Play();
            this._time2FinishInmunity = Time.time + inmunityTimeWhenHitted;
            changeInmunityToPlayer(true);
            reducePlayerLife();
        }
    }

    
    private void changeInmunityToPlayer(bool isInmunity)
    {
        this._isPlayerInInmunityEffect = isInmunity;
        _animator.SetBool("isHitted", isInmunity);
    }
}
