using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Explosion;
    public float DelayTime;

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("Bullet"))
        {
            Instantiate(Explosion,transform);
            Destroy(gameObject, DelayTime);
        }
    }
}
