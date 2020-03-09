// Created following the tutorial here: https://www.patrykgalach.com/2019/03/28/implementing-factory-design-pattern-in-unity/

using UnityEngine;

public abstract class Factory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    private T prefab;

    public T GetNewInstance()
    {
        return Instantiate(prefab);
    }
}
