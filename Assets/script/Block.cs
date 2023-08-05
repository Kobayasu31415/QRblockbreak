using UnityEngine;
using DG.Tweening;

class Block : MonoBehaviour, IBreakable
{
    float m_deltaTime;

    public void OnBreak()
    {
        transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InOutQuart).OnComplete(() => Destroy(gameObject));
        //transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.).OnComplete(()=> Destroy(gameObject));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            OnBreak();
        }
    }

    void Start()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;

        float sum;
        sum = x + y;
        sum = sum /10;
        m_deltaTime = sum;
    }

    void Update()
    {
        m_deltaTime += Time.deltaTime;

        if (m_deltaTime > 2)
        {
            transform.DOScale(0.2f, 0.2f).SetLoops(2, LoopType.Yoyo);
            m_deltaTime = 0f;
        }
    }
}