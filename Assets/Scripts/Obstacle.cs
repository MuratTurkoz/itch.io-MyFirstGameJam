using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player"))
        {
            Vector3 hitNormal = collision.GetContact(0).normal;
            float hitDot = Vector3.Dot(hitNormal, Vector3.forward);
            Debug.Log(hitNormal);

            if (hitDot > 0.99f)
            {
                GameInstance.Instance.Lose();
                //Destroy(collision.gameObject);
            }
            else
            {
                collision.rigidbody.AddForce(-hitNormal * 100*Time.deltaTime, ForceMode.Impulse);
            }
        }

    }
}
