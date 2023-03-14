using UnityEngine; 

class Ball :MonoBehaviour
{
    [SerializeField]
    float Speed = 2f;
    Vector3 m_position;
    Vector3 m_velocity;

    int m_destroyFlag = 0;

    [SerializeField]
    int NumofReflect;

    float m_boundaryTop;
    float m_boundaryBottom;
    float m_boundaryLeft;
    float m_boundaryRight;

    float m_ShotOffset = 5f;

    Renderer m_renderer;
    float m_radius;

    void Awake()
    {
        m_renderer = GetComponent<Renderer>();
        Init();
    }

    void Init()
    {
        m_radius = m_renderer.bounds.extents.x;
        //barの太さを考慮してない
        transform.position +=  m_radius * Vector3.up * m_ShotOffset;
        m_position = transform.position;

        m_velocity = Speed * Vector3.up;
        m_boundaryTop = Camera.main.ViewportToWorldPoint(Vector2.up).y;
        m_boundaryBottom = Camera.main.ViewportToWorldPoint(Vector2.zero).y;
        m_boundaryLeft = Camera.main.ViewportToWorldPoint(Vector2.zero).x;
        m_boundaryRight = Camera.main.ViewportToWorldPoint(Vector2.right).x;
    }

    void Update()
    {
        m_position +=  m_velocity * Time.deltaTime;
        transform.position = m_position;
        boundScreen();
        removeBall();
    }
    
    void OnCollisionEnter(Collision collision) 
        {    
            m_velocity = Vector3.Reflect(m_velocity, collision.contacts[0].normal);
            m_destroyFlag = 0; 
        }

    void boundScreen()
    {
        if(m_position.y > m_boundaryTop - m_radius)
        {
            m_velocity.y = -Mathf.Abs(m_velocity.y);
            m_destroyFlag++;
        }
        if (m_position.x > m_boundaryRight - m_radius)
        {
            m_velocity.x = -Mathf.Abs(m_velocity.x);
            m_destroyFlag++;
        }
        if (m_position.x < m_boundaryLeft + m_radius)
        {
            m_velocity.x = Mathf.Abs(m_velocity.x);
            m_destroyFlag++;
        }
    }
    
    void removeBall()
    {
        if((m_position.y < m_boundaryBottom)||(m_destroyFlag > NumofReflect))
        {
            Destroy(gameObject);
            m_destroyFlag = 0;
        }
    }
}

