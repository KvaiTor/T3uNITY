using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameActive
{
    public class AssemblyShop : MonoBehaviour
    {
        public static List<GameObject> ListDiamond = new List<GameObject>();
        void Start()
        {
            StartCoroutine(AssemblerPunkt());
        }
        private IEnumerator AssemblerPunkt()
        {
            while (true)
            {
                yield return new WaitForSeconds(7f);
                if (ControlPar.AvailableSeats2 > ListDiamond.Count && GameActive.CreatureGold.ListGoldRing.Count != 0 && GameActive.PlayerInvent.ListOre2.Count != 0)
                {
                    ListDiamond.Add(Instantiate(Resources.Load("Diamond", typeof(GameObject)) as GameObject,
                          new Vector3(Random.Range(256.59f, 247.18f), 0.6f, Random.Range(243.82f, 239.6711f)), Quaternion.identity));
                    Destroy(GameActive.PlayerInvent.ListOre2[0]);
                    GameActive.PlayerInvent.ListOre2.RemoveAt(0);
                    Destroy(GameActive.CreatureGold.ListGoldRing[0]);
                    GameActive.CreatureGold.ListGoldRing.RemoveAt(0);
                }
            }
        }
    }
}