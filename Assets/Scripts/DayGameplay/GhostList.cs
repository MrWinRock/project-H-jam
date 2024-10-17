using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DayGameplay
{
    public class GhostList : MonoBehaviour
    {
        public Sprite[] ghosts;
        public Sprite[] imposters;
        public Sprite[] miniCards;
        public Image[] cards;

        public int EntitySize;

        void Start()
        {
            EntitySize = ghosts.Length + imposters.Length;
        }
        
        public void setGhost(int index, int entity) {}
    }
}