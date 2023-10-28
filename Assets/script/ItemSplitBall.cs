using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ItemSplitBall : Item
{
    public override void Activate()
    {
        EventSender.Instance.OnSplitBall();
        Debug.Log("SplitBall");
        Destroy(gameObject);
    }
}