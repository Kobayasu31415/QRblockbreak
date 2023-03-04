using UnityEngine;

class Block : MonoBehaviour, IBreakable
{
    public void OnBreak()
    {
        Destroy(gameObject);
    }

     void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            OnBreak();
        }            
    }
}