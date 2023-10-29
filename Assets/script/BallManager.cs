using UnityEngine;

public class BallManager : SingletonMonoBehaviour<BallManager>
{
    public int MaxBallCount { get; set; } = 100; // 最大ボール数を設定
    private int currentBallCount = 0; // 現在のボール数
    [SerializeField] GameObject m_ballPrefab = null; // ボールのプレハブ

    public bool CanCreateBall()
    {
        return currentBallCount == 0;
    }

    public bool CanSplitBall()
    {
        return currentBallCount < MaxBallCount;
    }

    public void CreateBall(Vector3 position, Quaternion rotation)
    {
        if (!CanCreateBall()) return;

        // ボールの生成処理
        Instantiate(m_ballPrefab, position, rotation);

        currentBallCount++;
    }

    public void SplitBall(Vector3 position, Quaternion rotation, Vector3 velocity)
    {
        if (!CanSplitBall()) return;

        // ボールの分裂処理
        var ballObj = Instantiate(m_ballPrefab, position, rotation);
        Ball ball  = ballObj.GetComponent<Ball>();
        ball.m_velocity = Quaternion.AngleAxis(30, Vector3.forward) * velocity;
        currentBallCount++;
    }

    public void DestroyBall()
    {
        // ボールの破壊処理
        //Destroy(ball);

        currentBallCount--;
    }
}