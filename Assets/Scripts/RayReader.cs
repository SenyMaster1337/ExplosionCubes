using System;
using UnityEngine;

public class RayReader : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;

    private RaycastHit _hit;
    private Ray _ray;

    public event Action<GameObject> CreateCubes;
    public event Action ExplosionCubes;

    private void OnEnable()
    {
        _inputHandler.Clicked += CheckRay;
    }

    private void OnDisable()
    {
        _inputHandler.Clicked -= CheckRay;
    }

    private void CheckRay()
    {
        _ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.tag == "Object")
            {
                CreateCubes?.Invoke(_hit.collider.gameObject);
                ExplosionCubes?.Invoke();
                Destroy(_hit.collider.gameObject);
            }
        }
    }
}
