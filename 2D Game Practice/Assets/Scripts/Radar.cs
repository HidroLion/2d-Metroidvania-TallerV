using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Radar : MonoBehaviour
{
    // Start is called before the first frame update
    MoveIA movement;

    void Awake()
    {
        movement = GetComponent<MoveIA>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            movement.State = 1;
            movement.PlayerTarget = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            movement.State = 0;
        }
    }
}
