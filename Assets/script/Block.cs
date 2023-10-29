using UnityEngine;
using DG.Tweening;

class Block : MonoBehaviour, IBreakable
{
    float m_deltaTime;
    float m_CreateItemRatio = 0.2f;

    void Awake()
    {
        // Tweenの最大容量を500、シーケンスの最大容量を100に設定する例
        DOTween.SetTweensCapacity(500, 100);

        // その後でDOTweenを初期化
        DOTween.Init();
    }
    public void OnBreak()
    {
        transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InOutQuart).OnComplete(() => Destroy(gameObject));
        CreateItem();
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

    void CreateItem(){
        if(Random.Range(0f,1f) < m_CreateItemRatio){
            int index = Random.Range(0, BlockManager.Instance.m_itemPrefab.Length);
            Instantiate(BlockManager.Instance.m_itemPrefab[index], transform.position, Quaternion.identity);
        }
    }
}