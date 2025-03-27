using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    private static readonly Dictionary<Type, Action<object>> _events = new();

    // �ݹ�� ���� ���۸� ��Ī ���� (Unsubscribe ���)
    private static readonly Dictionary<Delegate, Action<object>> _delegateLookup = new();

    // ����
    public static void Subscribe<T>(Action<T> callback)
    {
        Action<object> wrapper = (obj) => callback((T)obj);
        _delegateLookup[callback] = wrapper;

        if (_events.TryGetValue(typeof(T), out var existing))
            _events[typeof(T)] += wrapper;
        else
            _events[typeof(T)] = wrapper;
    }
    //��������
    public static void Unsubscribe<T>(Action<T> callback)
    {
        if (_delegateLookup.TryGetValue(callback, out var wrapper))
        {
            if (_events.TryGetValue(typeof(T), out var existing))
                _events[typeof(T)] -= wrapper;

            _delegateLookup.Remove(callback);
        }
    }
    // �̺�Ʈ ����
    public static void Publish<T>(T evt)
    {
        if (_events.TryGetValue(typeof(T), out var action))
            action?.Invoke(evt);
    }
}
# region �̺�Ʈ ���� ��뿹��
/*// 1. �̺�Ʈ ������ Ÿ�� ����
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
    // �̺�Ʈ ����
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
    // �̺�Ʈ ����
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
        Debug.Log("�÷��̾� ���" + e.playerName);
        gameOverPanel.SetActive(true);
    }
}*/

#endregion