using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;

    [SerializeField] private Raycast _raycast;

    private int _minChanceSpawn = 0;
    private int _maxChanceSpawn = 6;

    private float _multipleSpawnShance = 0.5f;
    private float _multipleLocalScale = 0.5f;

    private void OnEnable()
    {
        _raycast.UserClicedOnCube += Work;
    }

    private void OnDisable()
    {
        _raycast.UserClicedOnCube -= Work;
    }


    private void Work(Cube cube)
    {
        if (RoolChanceSpawn(cube.SpawnChance))
        {
            int nuber = Random.Range(_minChanceSpawn, _maxChanceSpawn);

            for (int i = 0; i < nuber; i++)
            {
                Spawn(cube, cube.SpawnChance);
            }

        }

        cube.Destroy();
    }

    private void Spawn(Cube cube, float SpawnChance)
    {
        SpawnChance *= _multipleSpawnShance;

        Cube clone = Instantiate(_prefabCube, cube.transform.position, cube.transform.rotation);

        clone.SetSpawnChance(SpawnChance);

        clone.SetScale(cube.transform.localScale * _multipleLocalScale);
    }

    private bool RoolChanceSpawn(float chance)
    {
        int minRollShance = 0;
        int maxRollShance = 100;

        return Random.Range(minRollShance, maxRollShance) <= chance;
    }
}