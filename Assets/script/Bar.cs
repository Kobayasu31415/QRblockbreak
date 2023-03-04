using UnityEngine;

class Bar : MonoBehaviour
{
    Vector3 m_mousePose;
    [SerializeField]
    Ball m_ballPrefab;

    void Update()
    {
        m_mousePose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = m_mousePose;
        transform.position = new Vector3(m_mousePose.x, transform.position.y ,transform.position.z);

        if(Input.GetMouseButton(0))
        {
            CreateBall();
        }
    }


    void CreateBall()
    {
        var ball = Instantiate(m_ballPrefab,transform.position,transform.rotation);
        //ball.transform.position = transform.position;
    }
}