using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIA : MonoBehaviour
{
    public Vector3 PlayerTarget;
    public Transform DefaultPos;

    public float Speed;
    public int State;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(State == 1)
        {
            transform.GetChild(0).position = Vector2.MoveTowards
                (transform.GetChild(0).position, PlayerTarget, Time.deltaTime * Speed);
            RotateAnim(PlayerTarget);
        }
        else if (State == 0)
        {
            transform.GetChild(0).position = Vector2.MoveTowards
                (transform.GetChild(0).position, DefaultPos.position, Time.deltaTime * Speed);
            RotateAnim(DefaultPos.position);
        }
    }

    public void RotateAnim(Vector3 Pos)
    {
        PlayerTarget = Pos;
        float x = (transform.GetChild(0).position - Pos).x;

        if (x >= 0)
        {
            transform.GetChild(0).localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
        }
    }

}
