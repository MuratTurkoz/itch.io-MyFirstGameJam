using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Collectable
{
    //protected override void OnCollected()
    //{
    //    throw new System.NotImplementedException();
    //}
    protected override void OnCollected()
    {
        GameInstance.Instance.Gold++;
        Debug.Log(GameInstance.Instance.Gold);
    }
}
