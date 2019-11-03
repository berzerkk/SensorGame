using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public int _scoring = 0;
    private TextMeshPro _text;
    private bool _autoIncrement = true;

    void Start()
    {
        _text = GetComponent<TextMeshPro>();
        InvokeRepeating("AutoIncrement", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        _text.SetText(_scoring.ToString());
    }
    public void AddScore(int score) {
        _scoring += score;
    }
    private void AutoIncrement() {
        if (_autoIncrement)
        _scoring++;
    }

    public int GetScore() {
        return _scoring;
    }
    public void stopIncrement() {
        _autoIncrement = false;
    }
}
