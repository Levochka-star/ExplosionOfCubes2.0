using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private Raycast _raycast;

    [SerializeField] private Detonator _detonator;
    [SerializeField] private CubeSpawner _cubeSpawner;

    private int _minValueSpawns = 0;
    private int _maxValueSpawns = 6;


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
        if (RoolChanceSpawn(cube.SpawnChance)||cube.SpawnChance == 100)
        {
            _cubeSpawner.Work(cube, GetValueSpawns(_minValueSpawns, _maxValueSpawns));
        }
        else
        {
            _detonator.Work(cube);
        }

        Destroy(cube.gameObject);
    }

    private bool RoolChanceSpawn(float chance)
    {
        int minRollShance = 0;
        int maxRollShance = 100;

        return Random.Range(minRollShance, maxRollShance) <= chance;
    }

    private int GetValueSpawns(int minValueSpawns, int maxValueSpawns)
    {
        return Random.Range(minValueSpawns, maxValueSpawns);
    }
}