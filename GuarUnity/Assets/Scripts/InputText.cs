using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    private string _inputedText;

    [SerializeField] private GameObject _inputField;
    [SerializeField] private GameObject _textDisplay;

    public void StoreName()
    {
        _inputedText = _inputField.GetComponent<Text>().text;
        _textDisplay.GetComponent<Text>().text = "merda";
    }

}
