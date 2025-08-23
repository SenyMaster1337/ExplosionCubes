using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private void OnEnable()
    {
        _cube.ColorChanging += SetMaterial;
    }

    private void OnDisable()
    {
        _cube.ColorChanging -= SetMaterial;
    }

    private void SetMaterial(GameObject cloneCube)
    {
        Renderer rendererCube = cloneCube.GetComponent<Renderer>();

        rendererCube.material.color = UnityEngine.Random.ColorHSV();
    }
}
