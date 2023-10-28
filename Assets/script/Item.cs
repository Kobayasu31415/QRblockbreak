using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float m_speed = 3f;

    float m_boundaryBottom;
    public virtual void Activate()
    {
        // ここにアイテムの効果を書く
    }

    void Start()
    {
        m_boundaryBottom = Camera.main.ViewportToWorldPoint(Vector2.zero).y;
    }

    void Update(){
        transform.position += Vector3.down * m_speed * Time.deltaTime;
        if(transform.position.y < m_boundaryBottom){
            Destroy(gameObject);
        }
    }
}
