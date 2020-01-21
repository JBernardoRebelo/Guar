using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    //[SerializeField] private static string _path = "Assets/Texts/BackStory_1.txt";
    //private StreamReader _file = new StreamReader(_path, true);

    [SerializeField] private float _wait = 0.1f;
    [SerializeField] private string _fullText;

    private void Start()
    {
        StartCoroutine(OutputText());
    }

    // Converts the file into separate lines and into separate chars to output
    private IEnumerator OutputText()
    {
        string currentText = "";

        for (int i = 0; i <= _fullText.Length; i++)
        {
            currentText = _fullText.Substring(0, i);

            GetComponent<Text>().text = currentText;

            yield return new WaitForSeconds(_wait);
        }
    }

}
