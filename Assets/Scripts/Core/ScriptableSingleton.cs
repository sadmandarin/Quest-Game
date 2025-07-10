using UnityEngine;

public abstract class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<T>(typeof(T).Name);
                if (instance == null)
                {
                    Debug.LogError($"ScriptableSingleton: No instance of {typeof(T).Name} found in Resources.");
                }
            }
            return instance;
        }
    }
}
