using System.Collections;
using System.Collections.Generic;
using System;
using System.IO.Ports;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private SpriteRenderer _mySpriteRenderer;
    public int _LifePoints = 5;
    public LifeCountHandler _lifeCountHandler;
    private Animator _animator;
    private float _attackInput;
    private bool _attack = false;
    private SerialPort _port;
    private float _stamina = 100.0f;
    public GameObject _staminaBar;
    public float _priceStamina, _regenStamina; 
    public GameObject _explosionGreen;
    public GameObject _finalScore;
    public Scoring _scoringScript;
    public SpawnDoggo _doggoScript;
    private int _inputVoice = 0;
    public int _minimumVoice = 50;
    void Start()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _port = new SerialPort("COM4", 9600);
        _port.Open();
        _animator.SetBool("Death", false);
        _animator.SetBool("Run", true);
        _animator.SetBool("Attack", false);
    }

    void Update()
    {
        if (_LifePoints <= 0)
        {
            transform.position = new Vector3(transform.position.x - 0.006f, transform.position.y, transform.position.z);
            Death();
        }
        else
        {
          //  _attackInput = Input.GetAxisRaw("Attack");
            _inputVoice =  Int32.Parse(_port.ReadLine());
            if (_inputVoice >= _minimumVoice && !_attack && _stamina >= _priceStamina * 2)
            {
                GetComponent<AudioSource>().Play();
                GetComponent<SpriteRenderer>().flipX = true;
                _animator.SetBool("Death", false);
                _animator.SetBool("Run", false);
                _animator.SetBool("Attack", true);
                _attack = true;

            }
            else if ((_inputVoice <= _minimumVoice || _stamina == 0) && _attack)
            {
                _attack = false;
                StartCoroutine(FlipPlayer());
                _animator.SetBool("Death", false);
                _animator.SetBool("Run", true);
                _animator.SetBool("Attack", false);

            }
        }
        if (_attack) {
            _stamina = (_stamina - _priceStamina < 0 ? 0 : _stamina - _priceStamina);
        } else {
            _stamina = (_stamina + _regenStamina > 100 ? 100 : _stamina + _regenStamina);
        }
        _staminaBar.transform.localScale = new Vector3(_stamina / 100.0f, 1,1);
    }
    public bool Alive()
    {
        return !(_LifePoints <= 0);
    }
    IEnumerator FlipPlayer()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().flipX = false;
    }
    public bool Attacking()
    {
        return _attack;
    }
    public void AddStamina(float _moreStamina) {
        _stamina = (_stamina + _moreStamina >= 100 ? 100 : _stamina + _moreStamina);
        Instantiate(_explosionGreen, new Vector3(2.221f,0.303f,0), Quaternion.identity);
    }
    private void Death()
    {
        if (_LifePoints == 0)
        {
            _animator.SetBool("Death", true);
            _animator.SetBool("Run", false);
            _animator.SetBool("Attack", false);
            _finalScore.GetComponent<TextMeshPro>().SetText("Your Score\n" + _scoringScript.GetScore().ToString());
            _finalScore.GetComponent<MeshRenderer>().enabled = true;
            _scoringScript.stopIncrement();
            _doggoScript.StopSpawn();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Doggo" || col.gameObject.tag == "DoggoParticle")
        {
            _mySpriteRenderer.color = new Color(250, 0, 0);
            _lifeCountHandler.RemoveLife(_LifePoints--);
            StartCoroutine(RemoveColorRed());
        }
    }
    IEnumerator RemoveColorRed()
    {
        yield return new WaitForSeconds(0.5f);
        _mySpriteRenderer.color = new Color(255, 255, 255);
    }

}
