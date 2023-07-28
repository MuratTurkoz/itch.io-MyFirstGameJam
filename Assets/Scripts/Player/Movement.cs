using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement :MonoBehaviour, IMove
{
    [SerializeField] float speed;
    public void Jump()
    {

    }

    public void Move()
    {
        gameObject.transform.Translate(Vector3.forward*Time.deltaTime*speed);
    }

    private void Update()
    {
        Move();
    }
}
