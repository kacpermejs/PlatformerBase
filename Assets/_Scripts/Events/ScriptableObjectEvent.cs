using UnityEngine;
using UnityEngine.Events;

public abstract class ScriptableObjectEvent : ScriptableObject {
    [System.NonSerialized]
    private UnityEvent action;

    protected virtual void OnEnable() {
        if (action == null) {
            action = new();
        }
    }

    public virtual void Register(UnityAction callback) {
        action.AddListener(callback);
    }

    public virtual void Unregister(UnityAction callback) {
        action.AddListener(callback);
    }

    public virtual void Raise() => action?.Invoke();
}

public abstract class ScriptableObjectEvent<T0> : ScriptableObject {
    [System.NonSerialized]
    private UnityEvent<T0> action;

    protected virtual void OnEnable() {
        if (action == null) {
            action = new();
        }
    }

    public virtual void Register(UnityAction<T0> callback) {
        action.AddListener(callback);
    }

    public virtual void Unregister(UnityAction<T0> callback) {
        action.AddListener(callback);
    }

    public virtual void Raise(T0 argument) => action?.Invoke(argument);
}

public abstract class ScriptableObjectEvent<T0, T1> : ScriptableObject {
    [System.NonSerialized]
    private UnityEvent<T0, T1> action;

    protected virtual void OnEnable() {
        if (action == null) {
            action = new();
        }
    }

    public virtual void Register(UnityAction<T0, T1> callback) {
        action.AddListener(callback);
    }

    public virtual void Unregister(UnityAction<T0, T1> callback) {
        action.AddListener(callback);
    }

    public virtual void Raise(T0 argument0, T1 argument1) => action?.Invoke(argument0, argument1);
}

public abstract class ScriptableObjectEvent<T0, T1, T2> : ScriptableObject {
    [System.NonSerialized]
    private UnityEvent<T0, T1, T2> action;

    protected void OnEnable() {
        if (action == null) {
            action = new();
        }
    }

    public virtual void Register(UnityAction<T0, T1, T2> callback) {
        action.AddListener(callback);
    }

    public virtual void Unregister(UnityAction<T0, T1, T2> callback) {
        action.AddListener(callback);
    }

    public virtual void Raise(T0 argument0, T1 argument1, T2 argument2) => action?.Invoke(argument0, argument1, argument2);
}