using TMPro;
using UnityEngine;

public class TaskCheckerPhase3 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _task1Text;

    [SerializeField] private DiceCheckerEvent _socket1;
    [SerializeField] private DiceCheckerEvent _socket2;
    [SerializeField] private DiceCheckerEvent _socket3;
    [SerializeField] private DiceCheckerEvent _socket4;
    [SerializeField] private DiceCheckerEvent _socket5;

    [SerializeField] private PineappleSpawner _woodSpawner;
    
    
    public void CheckDices()
    {
        if (_socket1.isDiceCorrect && _socket2.isDiceCorrect && _socket3.isDiceCorrect && _socket4.isDiceCorrect && _socket5.isDiceCorrect)
        {
            _task1Text.color = Color.green;
            _woodSpawner.Unlock();
        }
        else
        {
            _task1Text.color = Color.red;
        }
    }
}
