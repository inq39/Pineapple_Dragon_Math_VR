using UnityEngine;

public class PineappleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pineApplePrefab;
    [SerializeField] private Transform _spawnLocation;

    public void SpawnPineapple()
    {
        Instantiate(_pineApplePrefab, _spawnLocation.position, Quaternion.identity);
    }
    
}
