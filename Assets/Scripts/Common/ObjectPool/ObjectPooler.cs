using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Common.ObjectPool
{
    public class ObjectPooler : MonoBehaviour
    {
        #region Singleton

        public static ObjectPooler Instance;

        private void Awake()
        {
            if (Instance != this && Instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        #endregion Singleton

        public List<Pool> Pools;
        private Dictionary<string, Queue<GameObject>> _poolDictionary;

        private void Start()
        {
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();
            
            foreach (var pool in Pools)
            {
                Queue<GameObject> poolQueue = new Queue<GameObject>();
                
                for (int i = 0; i < pool.Size; i++)
                {
                    var obj = Instantiate(pool.Prefab);
                    obj.SetActive(false);
                    poolQueue.Enqueue(obj);
                    obj.transform.SetParent(transform);
                }
                
                _poolDictionary.Add(pool.Tag, poolQueue);
            }
        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!_poolDictionary.ContainsKey(tag))
                return null;
            
            var objToSpawn = _poolDictionary[tag].Dequeue();
            
            objToSpawn.SetActive(true);
            objToSpawn.transform.position = position;
            objToSpawn.transform.rotation = rotation;

            var pooledObj = objToSpawn.GetComponent<IPooledObject>();
            if (pooledObj != null)
            {
                pooledObj.OnObjectSpawn();
            }

            _poolDictionary[tag].Enqueue(objToSpawn);
            return objToSpawn;
        }

        [Serializable]
        public class Pool
        {
            public string Tag;
            public GameObject Prefab;
            public int Size;
        }
    }
}