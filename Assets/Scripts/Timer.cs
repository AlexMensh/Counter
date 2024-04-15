using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private int _maxValue;

    private Coroutine _timerCoroutine;

    private int value = 0;
    private float _delay = 0.5f;
    private bool _isActive = false;

    private void Start()
    {
        _timerText.text = value.ToString();
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSeconds(_delay);

        for (int i = value; i < _maxValue; i++)
        {
            value = i;

            DisplayCount(value);

            yield return wait;
        }
    }

    public void Switch()
    {
        _isActive = !_isActive;

        if (_isActive == false)
        {
            StopCoroutine(_timerCoroutine);
        }
        else
        {
            _timerCoroutine = StartCoroutine(Count());
        }
    }

    private void DisplayCount(int value)
    {
        _timerText.text = value.ToString();
    }
}