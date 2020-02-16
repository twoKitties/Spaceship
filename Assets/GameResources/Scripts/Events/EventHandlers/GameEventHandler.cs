using System.Collections.Generic;
using UnityEngine;
public abstract class GameEventHandler<T> : ScriptableObject
{
    protected List<IGameEventListener<T>> _listeners = new List<IGameEventListener<T>>();

    public void Register(IGameEventListener<T> listener)
    {
        if (_listeners.Contains(listener) == false)
            _listeners.Add(listener);
    }

    public void Unregister(IGameEventListener<T> listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }

    public void Raise(T data)
    {
        foreach (var listener in _listeners)
        {
            listener.OnEventRaised(data);
        }
    }
}
