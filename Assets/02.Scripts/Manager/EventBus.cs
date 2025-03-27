using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    private static readonly Dictionary<Type, Action<object>> _events = new();

    // 콜백과 람다 래퍼를 매칭 저장 (Unsubscribe 대비)
    private static readonly Dictionary<Delegate, Action<object>> _delegateLookup = new();

    // 구독
    public static void Subscribe<T>(Action<T> callback)
    {
        Action<object> wrapper = (obj) => callback((T)obj);
        _delegateLookup[callback] = wrapper;

        if (_events.TryGetValue(typeof(T), out var existing))
            _events[typeof(T)] += wrapper;
        else
            _events[typeof(T)] = wrapper;
    }
    //구독해제
    public static void Unsubscribe<T>(Action<T> callback)
    {
        if (_delegateLookup.TryGetValue(callback, out var wrapper))
        {
            if (_events.TryGetValue(typeof(T), out var existing))
                _events[typeof(T)] -= wrapper;

            _delegateLookup.Remove(callback);
        }
    }
    // 이벤트 발행
    public static void Publish<T>(T evt)
    {
        if (_events.TryGetValue(typeof(T), out var action))
            action?.Invoke(evt);
    }
}
# region 이벤트 버스 사용예시
/*// 1. 이벤트 데이터 타입 정의
public class PlayerDieEvent
{
    public string playerName;
    public PlayerDieEvent(string name)
    {
        playerName = name;
    }
}

public class Player : MonoBehaviour
{
    // 이벤트 발행
    void Die()
    {
        EventBus.Publish(new PlayerDieEvent("Player1"));
    }
}

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject gameOverPanel;
    protected override void Awake()
    {
        base.Awake();
    }
    // 이벤트 구독
    private void OnEnable()
    {
        EventBus.Subscribe<PlayerDieEvent>(OnPlayerDied);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<PlayerDieEvent>(OnPlayerDied);
    }

    void OnPlayerDied(PlayerDieEvent e)
    {
        Debug.Log("플레이어 사망" + e.playerName);
        gameOverPanel.SetActive(true);
    }
}*/

#endregion