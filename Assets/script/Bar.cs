using UnityEngine;

class Bar : MonoBehaviour
{
    [SerializeField]

    Vector3 m_mousePose;
    [SerializeField]
    Ball m_ballPrefab;
    public GameObject m_ball;

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
            CreateBall();
        }
    }


    void CreateBall()
    {
        m_ball = GameObject.FindWithTag("Ball");
        m_createBallPosition = transform.position + m_barThickness * Vector3.up * m_ShotOffset;
        //m_createBallPosition = transform.position + Vector3.up * m_ShotOffset;  
        if(m_ball == null){
            var ball = Instantiate(m_ballPrefab,m_createBallPosition,transform.rotation);
            //ball.transform.position= transform.position;
        }
    }
}