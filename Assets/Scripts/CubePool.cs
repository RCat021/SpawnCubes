using UnityEngine;
using UnityEngine.Pool;

public class CubePool : MonoBehaviour
{
    [SerializeField] private CubeView _prefab;

    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSiz = 5;

    private ObjectPool<CubeView> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<CubeView>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: ActivateCube,
            actionOnRelease: DiactivedCube,
            actionOnDestroy: DestroyCube,
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSiz);
    }

    private void ActivateCube(CubeView cube)
    {
        cube.Released += ReleaseCube;

        cube.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cube.gameObject.SetActive(true);
    }

    private void DiactivedCube(CubeView cube)
    {
        cube.gameObject.SetActive(false);
    }

    private void DestroyCube(CubeView cube)
    {
        Destroy(cube.gameObject);
    }

    public void ReleaseCube(CubeView cube)
    {
        cube.Released -= ReleaseCube;
        _pool.Release(cube);
    }

    public CubeView GetPoolObject()
    {
        return _pool.Get();
    }
}
