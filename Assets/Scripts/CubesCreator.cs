using System.Collections.Generic;
using UnityEngine;

public class CubesCreator : MonoBehaviour
{
    [SerializeField] private RayReader _test;
    [SerializeField] private GameObject _cube;

    private int _minPercentageValue = 50;
    private int _maxPercentageValue = 100;

    private void OnEnable()
    {
        _test.CreateCubes += AddCubes;
    }

    private void OnDisable()
    {
        _test.CreateCubes -= AddCubes;
    }

    private void AddCubes(GameObject cube)
    {
        if (GetBooleanValue(UnityEngine.Random.Range(0, _maxPercentageValue)))
        {
            int number = 2;
            var cloneCube = cube;

            Vector3 positionCubes = new Vector3(cube.transform.position.x, cube.transform.position.y, cube.transform.position.z);
            cloneCube = ChangeScale(cloneCube, cube, number);
            Renderer cubeRenderer = cloneCube.GetComponent<Renderer>();

            for (int i = 0; i < GetCubesCount(); i++)
            {
                ChangeColor(cubeRenderer);
                Instantiate(cloneCube, positionCubes, Quaternion.identity);
            }

            _minPercentageValue /= number;
            _maxPercentageValue /= number;
        }
    }

    private Renderer ChangeColor(Renderer cubeRenderer)
    {
        cubeRenderer.material.color = UnityEngine.Random.ColorHSV();

        return cubeRenderer;
    }

    private GameObject ChangeScale(GameObject cloneCube, GameObject cube, int number)
    {
        cloneCube.transform.localScale = cube.transform.localScale / number;

        return cloneCube;
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
