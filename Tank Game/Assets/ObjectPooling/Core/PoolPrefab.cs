using UnityEngine;

namespace ObjectPooling
{
    [System.Serializable]
    public class PoolPrefab
    {
        public string Name;
        public GameObject PrefabObject;
        public int Amount;
    }
}
