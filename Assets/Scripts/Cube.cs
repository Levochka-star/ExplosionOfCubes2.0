using UnityEngine;

public class Cube : MonoBehaviour
{
    [field:SerializeField] public float SpawnChance { get; private set; }
    [SerializeField] private Detonator detonator;
    
    public void SetSpawnChance(float valueChance)
    {
        SpawnChance = valueChance;
    }

    public void SetScale(Vector3 vector3)
    {
        transform.localScale = vector3;
    }

    public void Destroy()
    {
        Destroy(gameObject);

        detonator.Work();
    }
}
