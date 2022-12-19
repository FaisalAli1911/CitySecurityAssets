using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; private set; }

        protected IEnumerator WriteText(string input, Text textHolder,float delay,float delayBetweenLines)
        {
          

            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
               // DialogueLine.sound.Play();
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(delayBetweenLines);
            //yield return new WaitUntil(() => Input.GetMouseButton(0));
         finished = true;
        }
    }
}

