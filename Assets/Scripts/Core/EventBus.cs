using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class EventBus
{
    private static readonly Dictionary<Type, List<Delegate>> _subscribers = new();

    public static void Subscribe<T>(Action<T> callbañk)
    {
        var type = typeof(T);
        if (!_subscribers.ContainsKey(type))
            _subscribers[type] = new List<Delegate>();
        
        _subscribers[type].Add(callbañk);
    }

    public static void Unsubscribe<T>(Action<T> callbask)
    {
        var type = typeof(T);
        if (_subscribers.TryGetValue(type, out var list))
            list.Remove(callbask);
    }

    public static void Publish<T>(T eventData)
    {
        var type = typeof(T);
        if (_subscribers.TryGetValue(type, out var list))
            foreach (var callback in list.Cast<Action<T>>().ToList())
                callback.Invoke(eventData);
    }
}
