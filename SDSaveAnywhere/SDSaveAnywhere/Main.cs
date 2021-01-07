using UnityEngine;
using Beam;

namespace SDSaveAnywhere
{
    public class Main : MonoBehaviour
    {
        public void SaveGame()
        {
            if (PlayerRegistry.LocalPlayer != null)
            {
                SaveManager.Save(Game.Mode);
            }
        }
    }
}