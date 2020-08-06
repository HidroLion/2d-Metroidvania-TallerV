using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Move : MonoBehaviour
{

    [SerializeField] Transform pos1, pos2;
    [SerializeField] float speed;

    Vector2 nextPos;

    // Start is called before the first frame update
    void Awake()
    {
        nextPos = pos1.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }

        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

}
