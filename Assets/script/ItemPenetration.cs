using UnityEngine;
using UnityEngine.Events;

public class ItemPenetration : Item
{
    public override void Activate()
    {
        EventSender.Instance.OnPenetration();
        Debug.Log("Penetration");
        Destroy(gameObject);
    }
}