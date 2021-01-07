using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Beam.Events;
using Beam.UI;
using Beam;

namespace SDSaveAnywhere
{
    public class Menu : MonoBehaviour
    {
        public bool Visible = true;
        private bool saved = false;
        private Rect _window;

        public void Start()
        {
            this._window = new Rect(10f, 10f, 250f, 150f);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                this.Visible = !this.Visible;
            }
        }
        public void OnGUI()
        {
            if (!this.Visible)
            {
                if (saved)
                    saved = false;
                return;
            }
            this._window = GUILayout.Window(0, this._window, new GUI.WindowFunction(this.Draw), "SDSaveAnywhere", new GUILayoutOption[0]);
        }
        public void Draw(int id)
        {
            if(saved)
            {
                GUILayout.Label("Saved", new GUILayoutOption[0]);
            }
            else
            {
                GUILayout.Label("Not saved", new GUILayoutOption[0]);
            }
            
            Main MyMainObj = Loader.myobj.GetComponent<Main>();
            if (GUILayout.Button("Save", new GUILayoutOption[0]))
            {
                MyMainObj.SaveGame();
                saved = true;
            }
            if (GUILayout.Button("Unload Mod", new GUILayoutOption[0]))
            {
                Loader.Unload();
            }
            GUILayout.Label("Open/Close with F1", new GUILayoutOption[0]);
            GUILayout.Space(10f);
            GUILayout.Label("Made by deadkex", new GUILayoutOption[0]);
            GUI.DragWindow();
        }
    }
}
