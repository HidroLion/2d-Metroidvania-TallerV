using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRadar : MonoBehaviour
{
    ShootController shoot;

    // Start is called before the first frame update
    void Awake()
    {
        shoot = GetComponent<ShootController>();
    }

    void OnTriggerStay2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            shoot.State = 1;
            shoot.Target = target.gameObject.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            shoot.State = 0;
        }
    }
}
