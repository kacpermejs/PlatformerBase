using UnityEngine;
/// <summary>
/// Generic singleton base class for MonoBehaviours with DontDestroyOnLoad.
/// </summary>
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {
    private static T _instance;
    private static object _lock = new object();
    private static bool _applicationIsQuitting;

    /// <summary>
    /// Access the instance of this singleton.
    /// </summary>
    public static T Instance {
        get {
            if (_applicationIsQuitting) {
                Debug.LogWarning($"[SingletonMonoBehaviour] Instance '{typeof(T)}' already destroyed on application quit.");
                return null;
            }

            lock (_lock) {
                if (_instance == null) {
                    // Try to find existing instance in the scene
                    _instance = FindAnyObjectByType<T>();

                    if (_instance == null) {
                        Debug.LogError($"[SingletonMonoBehaviour] No instance of {typeof(T)} found in the scene. Make sure it exists before accessing it.");
                    } else {
                        DontDestroyOnLoad(_instance.gameObject);
                    }
                }

                return _instance;
            }
        }
    }

    /// <summary>
    /// Unity Awake. Ensures only one instance exists.
    /// </summary>
    protected virtual void Awake() {
        if (_instance == null) {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        } else if (_instance != this) {
            Debug.LogWarning($"[SingletonMonoBehaviour] Duplicate instance of {typeof(T)} detected. Destroying the new one.");
            Destroy(gameObject);
        }
    }

    protected virtual void OnApplicationQuit() {
        _applicationIsQuitting = true;
    }

    protected virtual void OnDestroy() {
        if (_instance == this) {
            _instance = null;
        }
    }
}
