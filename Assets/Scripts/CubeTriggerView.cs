using UnityEngine;

[RequireComponent (typeof(CubeView))]
public class CubeTriggerView : MonoBehaviour
{
    private CubeView _cube;

    private void Awake()
    {
       _cube = GetComponent<CubeView>();
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.TryGetComponent<GroundView>(out var ground))
        {
            _cube.ChangeColor();
            _cube.Destroy();
        }
    }
}
