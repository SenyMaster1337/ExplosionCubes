using System;
using UnityEngine;

public class CubesCreator : MonoBehaviour
{
    [SerializeField] private RayReader _rayReader;

    private int _minPercentageValue = 50;
    private int _maxPercentageValue = 100;

    public event Action<Vector3, Vector3> CubeCreated;

    private void OnEnable()
    {
        _rayReader.CreateCubes += AddCubes;
    }

    private void OnDisable()
    {
        _rayReader.CreateCubes -= AddCubes;
    }

    private void AddCubes(Vector3 cubePosition, Vector3 cubeSize)
    {
        if (GetBooleanValue(UnityEngine.Random.Range(0, _maxPercentageValue)))
        {
            int number = 2;

            for (int i = 0; i < GetCubesCount(); i++)
            {
                CubeCreated?.Invoke(cubePosition, cubeSize);
            }

            _minPercentageValue /= number;
            _maxPercentageValue /= number;
        }
    }

    private int GetCubesCount()
    {
        int minCubesCount = 2;
        int maxCubesCount = 6;

        int cubesCount = UnityEngine.Random.Range(minCubesCount, maxCubesCount);

        return cubesCount;
    }

    private bool GetBooleanValue(int percentageValue)
    {
        return percentageValue > _minPercentageValue;
    }
}
