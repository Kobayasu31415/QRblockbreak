using UnityEngine;
using UnityEngine.Events;

public class EventSender : SingletonMonoBehaviour<EventSender>
{
    public event UnityAction m_PenetrationEvent;
    public event UnityAction m_SplitBallEvent;

    public void OnPenetration()
    {
        if (m_PenetrationEvent != null)
        {
            m_PenetrationEvent.Invoke();
        }
    }

    public void OnSplitBall()
    {
        if (m_SplitBallEvent != null)
        {
            m_SplitBallEvent.Invoke();
        }
    }
}