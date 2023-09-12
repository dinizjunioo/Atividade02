using UnityEngine;

/// <summary>
/// A static instance is similar to a singleton, but instead of destroying any new
/// instances, it overrides the current instance. This is handy for resetting the state
/// and saves you doing it manually
/// </summary>
public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour 
{

    private static T _instance = null;
    private static T seila = null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindAnyObjectByType<T>();
                if (_instance != null)
                {
                    var singletonObj = new GameObject();
                    singletonObj.name = typeof(T).ToString();
                    _instance = singletonObj.AddComponent<T>();
                }
            }

            return _instance;
        }

    }

    protected virtual void Awake()
    {
        // Garante que só existe uma instância em execução
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("Já existe uma instância de " + typeof(T) + ". Destruindo a instância duplicada.");
            Destroy(gameObject);
        }
        else
        {
            _instance = this as T;
        }
    }
    //public static T Instance { get; private set; }
    //protected virtual void Awake() => Instance = this as T;

    protected virtual void OnApplicationQuit() {
        _instance = null;
        Destroy(gameObject);
    }


}

/// <summary>
/// This transforms the static instance into a basic singleton. This will destroy any new
/// versions created, leaving the original instance intact
/// </summary>
public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour {
    protected override void Awake() {
        if (Instance != null) Destroy(gameObject);
        base.Awake();
    }
}

/// <summary>
/// Finally we have a persistent version of the singleton. This will survive through scene
/// loads. Perfect for system classes which require stateful, persistent data. Or audio sources
/// where music plays through loading screens, etc
/// </summary>
public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour {
    protected override void Awake() {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}

