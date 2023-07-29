using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected();
            gameObject.SetActive(false);
        }
    }
    //protected abstract void OnCollected();
    protected abstract void OnCollected();


}
