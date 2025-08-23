using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubesCreator _cubesCreator;
    [SerializeField] private GameObject _prefab;

    public event Action<GameObject> ColorChanging;

    private void OnEnable()
    {
        _cubesCreator.CubeCreated += Init;
    }

    private void OnDisable()
    {
        _cubesCreator.CubeCreated -= Init;
    }

    private void Init(Vector3 cubePosition, Vector3 cubeSize)
    {
        int number = 2;

        var cloneCube = Instantiate(_prefab, cubePosition, Quaternion.identity);

        cloneCube.transform.localScale = cubeSize / number;

        ColorChanging?.Invoke(cloneCube);
    }
}
