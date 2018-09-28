using UnityEngine;
using ObjectPooling;

public class TestObject : PoolObject {

    [SerializeField] private float moveSpeed;
    [SerializeField] private float duration;
    private float lifeTimer;

    void Update () {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        lifeTimer += Time.deltaTime;
        if(lifeTimer >= duration)
        {
            Destroy();
        }
	}

    public override void OnObjectReuse()
    {
        lifeTimer = 0;
    }
}
