using UnityEngine;

public abstract class GenericObjectFactory<T> : MonoBehaviour where T : Object
{
    [SerializeField]
    private T prefab;

    public virtual T GetNewInstance()
    {
        return Instantiate(prefab);
    }
}
