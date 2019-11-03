using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParrallax : MonoBehaviour
{
    public GameObject _background1, _background2, _background3, _background4, _background5;
    public float _speed1, _speed2, _speed3, _speed4, _speed5;
    void Start() {
    }

    void Update() {
        Parrallax(_background1, _speed1);
        Parrallax(_background2, _speed2);
        Parrallax(_background3, _speed3);
        Parrallax(_background4, _speed4);
        Parrallax(_background5, _speed5);
    }
    private void Parrallax(GameObject background, float speed) {
        background.transform.position = new Vector3(background.transform.position.x - speed, background.transform.position.y, background.transform.position.z);
        if (background.transform.position.x <= -7.84f)
                    background.transform.position = new Vector3(7.52f, background.transform.position.y, background.transform.position.z);

    }
}
