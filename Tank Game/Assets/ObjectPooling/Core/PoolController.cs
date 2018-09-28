using UnityEngine;
using System.Collections.Generic;

namespace ObjectPooling
{
    public class PoolController : MonoBehaviour
    {
        private Dictionary<string, Queue<ObjectInstance>> poolDictionary = new Dictionary<string, Queue<ObjectInstance>>();

        public List<PoolPrefab> poolPrefabs = new List<PoolPrefab>();

        private static PoolController instance;

        public static PoolController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<PoolController>();
                }
                return instance;
            }
        }

        private void Start()
        {
            for(int i = 0; i < poolPrefabs.Count; i++)
            {
                CreatePool(poolPrefabs[i].Name, poolPrefabs[i].PrefabObject, poolPrefabs[i].Amount);
            }
        }

        private void CreatePool(string name, GameObject prefab, int poolSize)
        {
            if (!poolDictionary.ContainsKey(name))
            {
                poolDictionary.Add(name, new Queue<ObjectInstance>());

                GameObject poolHolder = new GameObject(prefab.name + " pool");
                poolHolder.transform.parent = transform;

                for (int i = 0; i < poolSize; i++)
                {
                    ObjectInstance newObject = new ObjectInstance(Instantiate(prefab) as GameObject);
                    poolDictionary[name].Enqueue(newObject);
                    newObject.SetParent(poolHolder.transform);
                }
            }
        }

        public void SpawnObject(string name, Vector3 position, Quaternion rotation)
        {
            if (poolDictionary.ContainsKey(name))
            {
                ObjectInstance objectToSpawn = poolDictionary[name].Dequeue();
                poolDictionary[name].Enqueue(objectToSpawn);

                objectToSpawn.Use(position, rotation);
            }
        }
    }
}
