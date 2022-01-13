using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameActive
{
    public class ExtractionResurs : MonoBehaviour
    {
        public static List<GameObject> ListOre = new List<GameObject>();
        private void Start()
        {
            StartCoroutine(Extract());
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (ListOre.Count >= 20)
                    StartCoroutine(Extract());
            }
        }
        public static IEnumerator Extract()
        {
            while (ListOre.Count < ControlPar.AvailableSeats)
            {
                yield return new WaitForSeconds(1f);
                ListOre.Add(Instantiate(Resources.Load("Ore", typeof(GameObject)) as GameObject,
                    new Vector3(Random.Range(263f, 259f), 0.6f, Random.Range(233.35f, 237.43f)), Quaternion.identity));
            }
        }
    }
}
