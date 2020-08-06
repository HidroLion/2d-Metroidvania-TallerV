using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public GameObject Object;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("Bullet"))
        {
            anim.SetBool("IsDeath", true);
        }
    }

    public void DestroyOnTime()
    {
        Destroy(Object);
    }
}
