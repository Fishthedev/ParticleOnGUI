using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ParticleUI
{
    public class Main : MonoBehaviour
    {
        private static Rect _window = new Rect(20f, 20f, 500f, 450f);
        private static List<Particle> _particles = new List<Particle>();

        private void Start()
        {
            for (int i = 0; i < 250; i++)
            {
                var size =Random.Range(2, 5);
                var xLol = Random.Range(0, 1f);
                var yLol = Random.Range(0, 1f);
                _particles.Add(new Particle()
                {
                    position = new Rect(Random.Range(0, (int)_window.width), Random.Range(0, (int)_window.height), size, size),
                    xDir = xLol,
                    yDir = yLol
                });
            }
        }

        void OnGUI()
        {
            GUI.backgroundColor = Color.black;
            _window = GUI.Window(1234, _window, WindowMain, "Particle UI");
        }

        class Particle
        {
            public Rect position = default;
            public float xDir = 0f;
            public float yDir = 0f;
        }
        static void WindowMain(int id)
        {
            for (int i = 0; i < _particles.Count; i++)
            {
                var xPos = _particles[i].position.x + _particles[i].xDir;
                var yPos = _particles[i].position.y + _particles[i].yDir;
                _particles[i].position = new Rect(xPos, yPos, _particles[i].position.width, _particles[i].position.height);
                if (_particles[i].position.y > _window.height)
                {
                    var size = new System.Random().Next(2, 5);
                    var xLol = Random.Range(-1f, 1f);
                    var yLol = Random.Range(0, 1f);
                    _particles[i] = new Particle()
                    {
                        position = new Rect(new Rect(Random.Range(0, (int)_window.width), 0, size, size)),
                        xDir = xLol,
                        yDir = yLol
                    };
                }
                GUI.DrawTexture(_particles[i].position, Texture2D.whiteTexture, ScaleMode.StretchToFill, false, 0f, GUI.color, 0f, 50f);
            }
            GUI.DragWindow();
        }
    }
}