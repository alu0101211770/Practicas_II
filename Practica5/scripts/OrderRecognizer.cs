using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;
using Unity.FPS.Game;

namespace Unity.FPS.Gameplay 
{
    public class OrderRecognizer: MonoBehaviour
    {
        private KeywordRecognizer recognizer;
        public GameObject enemy;
        private GameObject player;

        void Start()
        {
            string[] keywords = {"Salud", "Enemigo", "Rápido", "Lento"};
            recognizer = new KeywordRecognizer(keywords);
            recognizer.OnPhraseRecognized += OnPhraseRecognized;
            recognizer.Start();
            player = GameObject.Find("Player");
        }

        private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
        {
            if (args.text == "Salud")
            {
                player.GetComponent<Health>().Heal(30f);
            } else if (args.text == "Enemigo")
            {
                Transform transform = player.GetComponent<Transform>();
                Instantiate(enemy, transform.position, transform.rotation);
            } else if (args.text == "Rápido")
            {
                PlayerCharacterController controller = player.GetComponent<PlayerCharacterController>();
                controller.MaxSpeedOnGround *= 1.5f;
            } else if (args.text == "Lento")
            {
                PlayerCharacterController controller = player.GetComponent<PlayerCharacterController>();
                controller.MaxSpeedOnGround /= 1.5f;
            }
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
            Debug.Log(builder.ToString());
        }
     
        void OnDestroy() 
        {
            recognizer.Dispose();
        }
    }
}