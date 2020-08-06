using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public int State;
    public GameObject Bullet;
    public Transform Gun;
    public float DelayTime;

    public Vector3 Target, Direction;
    public float Angle;
    public float offSet;

    public Animator anim;
    public float Timer;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (State == 0)
        {
            anim.SetBool("PlayerDetected", false);
            Timer = DelayTime;
        }
        if(State == 1)
        {
            anim.SetBool("PlayerDetected", true);

            Direction = Target - transform.position;
            Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
            transform.GetChild(0).GetChild(0).rotation = Quaternion.AngleAxis(Angle, Vector3.forward);

            if (Timer >= 0)
            {
                Timer = Timer - Time.deltaTime;
                if (Timer <= 0)
                {
                    Instantiate
                        (Bullet, Gun.position, gameObject.transform.GetChild(0).GetChild(0).rotation);
                    Timer = DelayTime;
                }
            }
        }
    }
}
