using UnityEngine;

public class GenericObjectFactory<T> : MonoBehaviour where T : Object
{
    [SerializeField]
    private T prefab;

    public T GetNewInstance()
    {
        return Instantiate(prefab);
    }
}
