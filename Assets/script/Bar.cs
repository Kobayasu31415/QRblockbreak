using Unity.VisualScripting;
using UnityEngine;

class Bar : MonoBehaviour
{
    [SerializeField]

    Vector3 m_mousePose;

    float m_barThickness;
    Vector3 m_createBallPosition;

    float m_ShotOffset = 2f; 

    void Awake()
    {
        m_barThickness = gameObject.transform.localScale.y;
        Debug.Log(m_barThickness);
    }

    void Update()
    {
        m_mousePose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = m_mousePose;
        transform.position = new Vector3(m_mousePose.x, transform.position.y ,transform.position.z);

        //if(Input.GetMouseButton(0))
        if(Input.GetMouseButtonDown(0))
        {
            m_createBallPosition = transform.position + m_barThickness * Vector3.up * m_ShotOffset;  
            BallManager.Instance.CreateBall(m_createBallPosition, transform.rotation);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            collision.gameObject.GetComponent<Item>().Activate();
        }
    }
}