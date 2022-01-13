using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameActive
{
    public class CreatureGold : MonoBehaviour
    {
        public static List<GameObject> ListCreatGold = new List<GameObject>();
        public static List<GameObject> ListGoldRing = new List<GameObject>();

        public static IEnumerator RecIn;

        private void Start()
        {
            RecIn = RecyclingIN();
            StartCoroutine(RecIn);
        }
        private IEnumerator RecyclingIN()
        {
            while (true)
            {
                yield return new WaitForSeconds(2f);
                if (ListCreatGold.Count < ControlPar.AvailableSeatsGold && GameActive.PlayerInvent.ListOre2.Count != 0)
                {
                    ListCreatGold.Add(Resources.Load("Ore", typeof(GameObject)) as GameObject);
                    Destroy(GameActive.PlayerInvent.ListOre2[0]);
                    GameActive.PlayerInvent.ListOre2.RemoveAt(0);
                    yield return StartCoroutine(RecyclingOut());
                }
            }
        }
        private IEnumerator RecyclingOut()
        {
            yield return new WaitForSeconds(1f);
            if (ControlPar.AvailableSeats2 > ListGoldRing.Count && ListCreatGold != null)
            {
                ListGoldRing.Add(Instantiate(Resources.Load("GoldRing", typeof(GameObject)) as GameObject,
                new Vector3(Random.Range(256.59f, 247.18f), 0.6f, Random.Range(243.82f, 239.6711f)), Quaternion.identity));
                ListCreatGold.RemoveAt(0);
            }
            yield break;
        }
    }
}