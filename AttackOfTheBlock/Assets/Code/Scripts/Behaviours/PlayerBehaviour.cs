using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int playerLives;
    public GameObject gameManager;
    public float inmunityTime;

    private bool _isPlayerInHittedEffect;
    private Animator _animator;
    private float _time2FinishInmunity;
    private AudioSource _audioSource;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (this._isPlayerInHittedEffect && this._time2FinishInmunity < Time.time)
        {
            quitInmunityToPlayer();
        }
        if (!_audioSource.isPlaying && playerLives<=0)
        {
            gameManager.GetComponent<GameManager>().finishGame();
        }
    }

    private void reducePlayerLive()
    {
        playerLives--;
        if (playerLives <= 0)
        {
            _audioSource.Play();
        }
    }

    public void hitPlayer()
    {
        if (!this._isPlayerInHittedEffect)
        {
            this._time2FinishInmunity += Time.time + inmunityTime;
            this._isPlayerInHittedEffect = true;
            _animator.SetBool("isHitted",true);
            reducePlayerLive();
        }
    }

    private void quitInmunityToPlayer()
    {
        this._isPlayerInHittedEffect = false;
        _animator.SetBool("isHitted", false);
    }


}
