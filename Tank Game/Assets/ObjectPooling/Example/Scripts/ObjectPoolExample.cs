using UnityEngine;
using ObjectPooling;

public class ObjectPoolExample : MonoBehaviour {

    [SerializeField] private string ObjectToSpawnName;

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            PoolController.Instance.SpawnObject(ObjectToSpawnName, transform.position, Quaternion.identity);
        }
	}
}
