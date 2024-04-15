using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private int maxValue;

    private int value = 0;
    private float _delay = 0.5f;
    private bool _isActive = false;

    private void Start()
    {
        _timerText.text = value.ToString();
    }

    private void Update()
    {
        if (_isActive == false)
        {
            StopAllCoroutines();
        }
        else
        {
            StartCoroutine(Count());
        }
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSeconds(_delay);

        for (int i = value; i < maxValue; i++)
        {
            value = i;

            DisplayCount(value);

            yield return wait;
        }
    }

    private void DisplayCount(int value)
    {
        _timerText.text = value.ToString();
    }

    public void Switch()
    {
        _isActive = !_isActive;
    }
}
