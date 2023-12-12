using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum DeformationType {
    Width,
    Height,
    Acceleration
}

public class GateAppearance : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    [SerializeField] Image _topImage;
    [SerializeField] Image _glassImage;

    [SerializeField] Color _colorPositive;
    [SerializeField] Color _colorNegative;
    [SerializeField] Color _colorAcceleration;

    // »конки увеличени€/уменьшени€ ширины
    [SerializeField] GameObject _expandLabel;
    [SerializeField] GameObject _shrinkLabel;

    // »конки увеличени€/уменьшени€ высоты
    [SerializeField] GameObject _upLabel;
    [SerializeField] GameObject _downLabel;

    // »конка ускорени€ персонажа
    [SerializeField] GameObject _accelerationLabel;


    public void UpdateVisual(DeformationType deformationType, int value)
    {
        string prefix = "";

        if (value > 0)
        {
            prefix = "+";
            SetColor(_colorPositive);
        }
        else if (value == 0)
        {
            SetColor(Color.gray);
        }
        else
        {
            SetColor(_colorAcceleration);
        }

        _text.text = prefix + value.ToString();

        _expandLabel.SetActive(false);
        _shrinkLabel.SetActive(false);
        _upLabel.SetActive(false);
        _downLabel.SetActive(false);
        _accelerationLabel.SetActive(false);

        if (deformationType == DeformationType.Width)
        {
            if (value > 0)
            {
                _expandLabel.SetActive(true);
            }
            else
            {
                _shrinkLabel.SetActive(true);
            }
        }
        else if (deformationType == DeformationType.Height)
        {
            if (value > 0)
            {
                _upLabel.SetActive(true);
            }
            else
            {
                _downLabel.SetActive(true);
            }
        }

        else if (deformationType == DeformationType.Acceleration)
        {
            _accelerationLabel.SetActive(true);
        }
    }

    void SetColor(Color color) {
        _topImage.color = color;
        _glassImage.color = new Color(color.r, color.g, color.b, 0.5f);
    }
}
