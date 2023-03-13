using UnityEngine;

class Bar : MonoBehaviour
{
    [SerializeField]

    Vector3 m_mousePose;
    [SerializeField]
    Ball m_ballPrefab;
    public GameObject m_ball;

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
        if(m_ball == null){
            var ball = Instantiate(m_ballPrefab,transform.position,transform.rotation);
            //ball.transform.position= transform.position;
        }
    }
}