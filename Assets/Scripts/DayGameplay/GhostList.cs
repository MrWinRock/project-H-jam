using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DayGameplay
{
    public class GhostList : MonoBehaviour
    {
        public GameObject[] ghosts;
        public GameObject[] imposters;
        public GameObject[] ghostMiniCards;
        public GameObject[] imMiniCards;
        public Image[] ghostMainCards;
        public Image[] imMainCards;
        public int EntitySize;

        void Start()
        {
            SpawnEntities();
        }

        public void setGhost(int index, int entity)
        {
            
        }

        private void SpawnEntities()
        {
            for (int i = 0; i < EntitySize; i++)
            {
                bool spawnImposter = Random.value < 0.2f; // 20% chance to spawn an imposter

                if (spawnImposter && i < imposters.Length)
                {
                    // Spawn imposter
                    Instantiate(imposters[i], transform.position, Quaternion.identity);
                    Instantiate(imMiniCards[i], transform.position, Quaternion.identity);
                    imMainCards[i].enabled = true;
                }
                else if (i < ghosts.Length)
                {
                    // Spawn ghost
                    Instantiate(ghosts[i], transform.position, Quaternion.identity);
                    Instantiate(ghostMiniCards[i], transform.position, Quaternion.identity);
                    ghostMainCards[i].enabled = true;
                }
            }
        }
    }
}