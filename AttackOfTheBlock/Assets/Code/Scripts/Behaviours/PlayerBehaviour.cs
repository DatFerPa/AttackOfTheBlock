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

    /**
     * <summary>Función que se encarga de pasarle a ala interfaz la vantidad de vidas de las que dispone el jugador</summary>
     */
    private void setLivesToUI()
    {
        gameManager.GetComponent<UIManager>().generateHearts(playerMaxLifes);
    }

    /**
     * <summary>Función que se encarga de disminuir la vida del jugador. En caso de que la vida llegue a cero, finaliza la aprtida</summary>
     */
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

    /**
     * <summary>Función que se encarga de sumanr una vida a la vida actual. La vida actual nunca supera a la vida máxima</summary>
     */
    public void getOneMoreLife()
    {
        if (_playerActualLifes < playerMaxLifes)
        {
            _playerActualLifes++;
            gameManager.GetComponent<UIManager>().fillInOutheart(_playerActualLifes - 1, true);
        }
    }

    /**
     * <summary>Función que se encarga de realizar las acciones resultantes cuando un enemigo golpea al jugador</summary>
     */
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

    /**
     * <summary>Función que se encarga de activar o desactivar la inmunidad del jugador</summary>
     * <param name="isInmunity">valor para activar o desactivar la inmunidad</param>
     */
    private void changeInmunityToPlayer(bool isInmunity)
    {
        this._isPlayerInInmunityEffect = isInmunity;
        _animator.SetBool("isHitted", isInmunity);
    }
}
