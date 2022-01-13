using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameActive
{
    public class PlayerInvent : MonoBehaviour
    {
        public static List<GameObject> ListInvent = new List<GameObject>();
        public static List<GameObject> ListOre2 = new List<GameObject>();
        private List<GameObject> Transfer = new List<GameObject>();

        private bool a, b;
        private int _row;
        private float _upvalue;

        public delegate void PlInvent(List<GameObject> Tr);
        public static event PlInvent PlInvented;

        private void Start()
        {
            PlInvented += Placement;
            PlInvented += ListInv;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("WarehouseIn"))
            {
                StopCoroutine(OutItems(a));
                a = true;
                StartCoroutine(GiveItems(a));

            }
            if (collision.gameObject.CompareTag("WarehouseOut"))
            {
                StopCoroutine(GiveItems(a));
                a = false;
                StartCoroutine(OutItems(a));
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("WarehouseIn"))
            {
                b = true;
            }
        }
        private void Update()
        {
            if (a)
            {
                Placement(Transfer);
            }
            else if (!a && ControlPar.AvailableSeats2 > ListOre2.Count)
            {
                foreach (GameObject itemUp in ListInvent)
                {
                    itemUp.transform.position = Vector3.MoveTowards(itemUp.transform.position,
                    new Vector3(252.1f, 0.6f, 241.8f), 5f * Time.deltaTime);
                }
            }
        }
        private IEnumerator GiveItems(bool s)
        {
            if (s)
            {
                while (GameActive.ExtractionResurs.ListOre.Count != 0)
                {
                    yield return null;
                    if (ControlPar._InventoryAll > ListInvent.Count)
                    {
                        foreach (GameObject itemUp in GameActive.ExtractionResurs.ListOre)
                        {
                            Transfer.Add(Instantiate(Resources.Load("Ore", typeof(GameObject)) as GameObject, itemUp.gameObject.transform.position, Quaternion.identity));
                            b = false;
                            for (int i = 0; i < Transfer.Count; i++)
                            {
                                _row = i;
                            }
                        }
                    }
                }
            }
            else
                yield break;
        }
        private IEnumerator OutItems(bool s)
        {
            _upvalue = 0;
            while (ListInvent.Count != 0)
            {
                yield return new WaitForSeconds(0.2f);
                if (ControlPar.AvailableSeats2 > ListOre2.Count && !s)
                {
                    ListOre2.Add(Instantiate(Resources.Load("Ore", typeof(GameObject)) as GameObject,
                    new Vector3(Random.Range(256.59f, 247.18f), 0.6f, Random.Range(243.82f, 239.6711f)), Quaternion.identity));
                    Destroy(ListInvent[0]);
                    ListInvent.RemoveAll(x => x == ListInvent[0]);
                }
                else
                    yield break;
            }
        }
        private void Placement(List<GameObject> tr)
        {
            if (!b)
            {
                foreach (GameObject Trans in tr)
                {
                    Trans.transform.position = Vector3.MoveTowards(Trans.transform.position,
                    gameObject.transform.position, 8 * Time.deltaTime);

                    for (int i = 0; i < GameActive.ExtractionResurs.ListOre.Count; i++)
                    {
                        Destroy(GameActive.ExtractionResurs.ListOre[i]);
                        GameActive.ExtractionResurs.ListOre.RemoveAll(x => x == GameActive.ExtractionResurs.ListOre[i]);
                    }
                }
            }
            else
            {
                foreach (GameObject Trans in tr)
                {
                    if (_row % 1 == 0)
                    {
                        _upvalue += 0.3f;
                        ListInv(ListInvent);
                    }
                }
            }
        }
        private void ListInv(List<GameObject> inv)
        {
            if (ControlPar._InventoryAll > inv.Count)
            {
                inv.Add(Instantiate(Resources.Load("Ore", typeof(GameObject)) as GameObject,
                 new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + _upvalue, gameObject.transform.position.z - 0.7f),
                 Quaternion.identity));
            }
            foreach (GameObject invent in inv)
                invent.transform.parent = gameObject.transform;
            b = true;
            for (int i = 0; i < inv.Count; i++)
            {
                Destroy(Transfer[i]);
                Transfer.RemoveAll(x => x == Transfer[i]);
            }
        }
        private void OnDestroy()
        {
            PlInvented -= Placement;
            PlInvented -= ListInv;
        }
    }
}
