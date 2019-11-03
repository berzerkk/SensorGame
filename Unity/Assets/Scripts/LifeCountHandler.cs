using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCountHandler : MonoBehaviour
{
public GameObject _life1, _life2, _life3, _life4, _life5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLife(int life) {
        switch(life) {
            case 1:
                _life1.SetActive(false);
            break;
            case 2:
                _life2.SetActive(false);
            break;
            case 3:
                _life3.SetActive(false);
            break;
            case 4:      
                _life4.SetActive(false);
            break;
            case 5:    
                _life5.SetActive(false);
            break;
        }
    }
}
