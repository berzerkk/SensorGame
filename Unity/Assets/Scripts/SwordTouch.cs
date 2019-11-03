using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTouch : MonoBehaviour
{
    public Player _player;
    public GameObject _explosion;
    public Scoring _scoring;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.tag == "Doggo" || col.gameObject.tag == "DoggoParticle") && _player.Attacking())
        {
            RunDoggo script = col.gameObject.GetComponent<RunDoggo>();
            script.Killed();
            _scoring.AddScore(10);
            if (col.gameObject.tag == "DoggoParticle") 
                _player.AddStamina(50);
            Instantiate(_explosion, new Vector3(1.995f, 0.256f, 0),  Quaternion.identity);
        }
    }
      void OnTriggerStay2D(Collider2D col)
    {
        if ((col.gameObject.tag == "Doggo" || col.gameObject.tag == "DoggoParticle") && _player.Attacking())
        {
            RunDoggo script = col.gameObject.GetComponent<RunDoggo>();
            script.Killed();
            _scoring.AddScore(10);
            if (col.gameObject.tag == "DoggoParticle")
                _player.AddStamina(50);
            Instantiate(_explosion, new Vector3(1.995f, 0.256f, 0),  Quaternion.identity);
        }
    }
}
