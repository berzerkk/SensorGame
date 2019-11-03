using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunDoggo : MonoBehaviour
{
    private float _speed;
    private Animator _animator;
    private bool _jump = false;
    public float _jumpSpeed;
    void Start()
    {
        _speed = UnityEngine.Random.Range(0.01f, 0.03f);
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()

    {
        transform.position = new Vector3(transform.position.x + _speed,
        (_jump ? transform.position.y + _jumpSpeed : (transform.position.y <= 0.283f ? transform.position.y : transform.position.y - _jumpSpeed * 2)),
        transform.position.z);
        if (transform.position.x >= 4f) {
            Destroy(gameObject);
        }
    }
    public void Killed() {
        Destroy(gameObject);
    }
     void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.name == "JumpDoggo") { //  && col.gameObject.GetComponent<Player>().Alive()
            _jump = true;
            _animator.SetBool("Run", false);
            _animator.SetBool("Jump", true);
        }
    }
     void OnTriggerExit2D (Collider2D col) {
        if (col.gameObject.name == "JumpDoggo") {
            _jump = false;
            _animator.SetBool("Run", true);
            _animator.SetBool("Jump", false);
        }
    }
}
