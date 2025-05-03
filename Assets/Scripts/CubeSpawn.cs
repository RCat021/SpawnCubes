using System.Collections;
using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    [SerializeField] private CubePool _pool;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField, Min(0)] private float _radiusSpawnPosition = 5f;
    [SerializeField, Min(0)] private float _timeSpawnCube = 0.4f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private Vector3 GetSpawnPosition()
    {
        float xPosition = GetRandomPosition(_spawnPoint.position.x);
        float zPosition = GetRandomPosition(_spawnPoint.position.z);

        return new Vector3(xPosition, _spawnPoint.position.y, zPosition);
    }

    private float GetRandomPosition(float basePosition)
    {
        return Random.Range(basePosition - _radiusSpawnPosition, basePosition + _radiusSpawnPosition);
    }

    private IEnumerator Spawn()
    {
        bool spawned = enabled;
        var time = new WaitForSeconds(_timeSpawnCube);

        while (spawned)
        {
            var cube = _pool.GetPoolObject();
            cube.transform.position = GetSpawnPosition();

            yield return time;
        }
    }
}
