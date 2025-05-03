using UnityEngine;

public class CubeTriggerZone : MonoBehaviour
{
    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.TryGetComponent<CubeView>(out var cube))
        { 
            cube.ChangeColor();
            cube.Destroy();
        }
    }
}
