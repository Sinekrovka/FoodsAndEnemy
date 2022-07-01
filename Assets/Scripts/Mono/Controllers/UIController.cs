using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Image _heathBar;
    public static UIController Instance;
    private float _healthBarScale;
    private void Awake()
    {
        Instance = this;
        _healthBarScale = 1f;
        _heathBar = transform.Find("Health/HealthBar").GetComponent<Image>();
    }

    private void Update()
    {
        _heathBar.fillAmount = _healthBarScale;
    }

    public float HealthBarScale
    {
        get => _healthBarScale;
        set => _healthBarScale = value;
    }
}
