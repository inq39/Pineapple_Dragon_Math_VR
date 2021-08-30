using UnityEngine;

public class PineappleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pineApplePrefab;
    [SerializeField] private Transform _spawnLocation;

    [SerializeField] private bool _pineappleUnlocked = false;
    private MeshRenderer _mr;

    private void Awake()
    {
        _mr = GetComponent<MeshRenderer>();
    }
    public void SpawnPineapple()
    {
        if (_pineappleUnlocked)
        {
            Instantiate(_pineApplePrefab, _spawnLocation.position, Quaternion.identity);
            Lock();
        }
    }

    public void Unlock()
    {
        _pineappleUnlocked = true;
        _mr.material.color = Color.green;
    }

    public void Lock()
    {
        _pineappleUnlocked = false;
        _mr.material.color = Color.red;
    }
}
