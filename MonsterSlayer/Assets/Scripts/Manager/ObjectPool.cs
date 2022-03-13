using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField]
    private GameObject _skeletonSlavePrefab;

    private Queue<Enemy> _skeletonSlavePool = new Queue<Enemy>();

    private void Awake()
    {
        Instance = this;

        Initialize(10);
    }
    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; ++i)
        {
            _skeletonSlavePool.Enqueue(CreateSkeletonSlave());
        }
    }

    private Enemy CreateSkeletonSlave()
    {
        Enemy newObj = Instantiate(_skeletonSlavePrefab).GetComponent<SkeletonSlave>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static Enemy GetSkeletonSlave()
    {
        if (Instance._skeletonSlavePool.Count > 0)
        {
            Enemy obj = Instance._skeletonSlavePool.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            Enemy newObj = Instance.CreateSkeletonSlave();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnSkeletonSlave(Enemy obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance._skeletonSlavePool.Enqueue(obj);
    }
}
