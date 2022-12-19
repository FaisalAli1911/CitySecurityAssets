using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder;

        [Header ("Text Options")]
        [SerializeField] private string input;
        public float delay;
       // [SerializeField] private Color textColor;
      //  [SerializeField] private Font textFont;

     //   [Header("Time parameters")]
      //  [SerializeField] private float delay;
      [SerializeField] private float delayBetweenLines;

      //  [Header("Sound")]
        public static AudioSource sound;
    
       [SerializeField] private Sprite characterSprite;
       [SerializeField] private Image imageHolder;

        private void Awake()
        {
            textHolder = GetComponent<Text>();
             textHolder.text = "";
            sound=gameObject.GetComponent<AudioSource>();
            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
           
        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, delay,delayBetweenLines));
        }
    }
}