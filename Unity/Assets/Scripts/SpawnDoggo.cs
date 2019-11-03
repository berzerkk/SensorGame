using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoggo : MonoBehaviour
{
    public GameObject _doggo;
    public GameObject _doggoParticle;


    public Scoring _scoring;

    private float _startMinSpawn, _startMaxSpawn, _currentMinSpawn, _currentMaxSpawn;
    private float _levelRatio;
    private float _currentLevel;
    private int _nextLevel = 50;
    private bool _spawn = true;

    void Start()
    {
        _currentLevel = 1.0f;
        _levelRatio = 1.0f;
        _startMinSpawn = 1.0f;
        _startMaxSpawn = 4.0f;
        _currentMinSpawn = _startMinSpawn / _levelRatio;
        _currentMaxSpawn = _startMaxSpawn / (_levelRatio - 0.5f);
        Invoke("Spawn", 0);
    }

    void Update()
    {
        if (_scoring.GetScore() >= _nextLevel)
        {
            _currentLevel += 1;
            _nextLevel *= 2;
            _levelRatio += 1.0f / _currentLevel;
            _currentMinSpawn = _startMinSpawn / _levelRatio;
            _currentMaxSpawn = _startMaxSpawn / (_levelRatio - 0.5f);
        }
    }
    private void Spawn()
    {
        Invoke("LaunchDoggo", 0);
        Invoke("Spawn", UnityEngine.Random.Range(_currentMinSpawn, _currentMaxSpawn)); // / _scoring

    }

    void LaunchDoggo()
    {
        if (_spawn)
            Instantiate((UnityEngine.Random.Range(0, 9) == 1 ? _doggoParticle : _doggo), new Vector3(0.1f, 0.283f, 0f), Quaternion.identity);
    }
    public void StopSpawn() {
        _spawn = false;
    }
}
