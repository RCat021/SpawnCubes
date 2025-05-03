using System;
using System.Collections;
using UnityEngine;

public class CubeView : MonoBehaviour
{
    [SerializeField] private Color _newColor;
    [SerializeField] private float _minTimeDestroy = 2f;
    [SerializeField] private float _maxTimeDestroy = 5f;

    private Renderer _renderer;
    private bool _isChangedColor = false;

    public event Action<CubeView> Release;

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void ChangeColor()
    {
        if (_isChangedColor == false)
        {
            _renderer.material.color = _newColor;
            _isChangedColor = true;
        }
    }

    public void Destroy()
    {
        StartCoroutine(DelayedDelete());
    }

    private IEnumerator DelayedDelete()
    {
        float timeDestroy = UnityEngine.Random.Range(_minTimeDestroy, _maxTimeDestroy);

        yield return new WaitForSeconds(timeDestroy);

        Release?.Invoke(this);
    }
}
