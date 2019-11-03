using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLife : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(0.51f);
        Destroy(gameObject);
    }
}
