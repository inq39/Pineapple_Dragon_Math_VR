using TMPro;
using UnityEngine;

public class TaskCheckerPhase1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _task1Text;
    [SerializeField] private TextMeshProUGUI _task2Text;
    [SerializeField] private TextMeshProUGUI _task3Text;

    [SerializeField] private DiceCheckerEvent _socket1;
    [SerializeField] private DiceCheckerEvent _socket2;
    [SerializeField] private DiceCheckerEvent _socket3;
    [SerializeField] private DiceCheckerEvent _socket4;
    [SerializeField] private DiceCheckerEvent _socket5;
    [SerializeField] private DiceCheckerEvent _socket6;
    [SerializeField] private DiceCheckerEvent _socket7;
    [SerializeField] private DiceCheckerEvent _socket8;
    [SerializeField] private DiceCheckerEvent _socket9;

    [SerializeField] private PineappleSpawner _pineappleSpawner;
    
    [SerializeField] private bool _row1Correct = false;
    [SerializeField] private bool _row2Correct = false;
    [SerializeField] private bool _row3Correct = false;
    
    public void CheckDices()
    {
        if (_socket1.isDiceCorrect && _socket2.isDiceCorrect && _socket3.isDiceCorrect)
        {
            _task1Text.color = Color.green;
            _row1Correct = true;
        }
        else
        {
            _task1Text.color = Color.red;
            _row1Correct = false;
        }
        
        if (_socket4.isDiceCorrect && _socket5.isDiceCorrect && _socket6.isDiceCorrect)
        {
            _task2Text.color = Color.green;
            _row2Correct = true;
        }
        else
        {
            _task2Text.color = Color.red;
            _row2Correct = false;
        }
        
        if (_socket7.isDiceCorrect && _socket8.isDiceCorrect && _socket9.isDiceCorrect)
        {
            _task3Text.color = Color.green;
            _row3Correct = true;
        }
        else
        {
            _task3Text.color = Color.red;
            _row3Correct = false;
        }

        if (_row1Correct && _row2Correct && _row3Correct)
        {
            _pineappleSpawner.Unlock();
        }
    }
}
