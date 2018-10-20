using System;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Text;
using UnityEngine.UI;

public class VoiceRecog : MonoBehaviour
{

    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;
    public GameObject Cube;
    public GameObject Sphere;
    public AnimateV2 dog;

    void Start()
    {
        m_Keywords = new string[4];
        m_Keywords[0] = "sit";
        m_Keywords[1] = "stand";
        m_Keywords[2] = "walk";
        m_Keywords[3] = "text";
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPharseRecognized;
        m_Recognizer.Start();
    }

    private void OnPharseRecognized(PhraseRecognizedEventArgs args)
    {
        float newX = UnityEngine.Random.Range(-3, 3);
        float newY = UnityEngine.Random.Range(-3, 3);
        //float newX = (0);
       // float newY = (0);
        float newZ = (1);

        if (args.text == m_Keywords[0])
        {
            Instantiate(Cube, new Vector3(newX, newZ, newY), Quaternion.identity);
            dog.SitButtonClicked();
        }

        if (args.text == m_Keywords[1])
        {
            Instantiate(Sphere, new Vector3(newX, newZ, newY), Quaternion.identity);
            dog.StandButtonClicked();
        }

        if (args.text == m_Keywords[2])
        {
            Instantiate(Sphere, new Vector3(newX, newZ, newY), Quaternion.identity);
            dog.Walk();
        }

        if (args.text == m_Keywords[3])
        {
            Instantiate(Sphere, new Vector3(newX, newZ, newY), Quaternion.identity);
            
        }


    }


    // Update is called once per frame
    void Update()
    {

    }
}




