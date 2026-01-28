using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;

    private float _multipleSpawnShance = 0.5f;
    private float _multipleLocalScale = 0.5f;

    public void Work(Cube cube, int valueCubs)
    {
        for (int i = 0; i < valueCubs; i++)
        {
            Spawn(cube, cube.SpawnChance);
        }
    }

    private void Spawn(Cube cube, float SpawnChance)
    {
        SpawnChance *= _multipleSpawnShance;

        Cube clone = Instantiate(_prefabCube, cube.transform.position, cube.transform.rotation);

        clone.SetSpawnChance(SpawnChance);

        clone.SetScale(cube.transform.localScale * _multipleLocalScale);
    }
}