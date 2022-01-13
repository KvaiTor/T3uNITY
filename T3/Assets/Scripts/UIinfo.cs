using UnityEngine;
using UnityEngine.UI;

namespace GameActive
{
    public class UIinfo : MonoBehaviour
    {
        public Text[] InfoText;
        void Start()
        {
            TextUI();
        }

        void Update()
        {
            TextUI();
        }

        private void TextUI()
        {


            if (GameActive.ExtractionResurs.ListOre.Count >= ControlPar.AvailableSeats)
                InfoText[0].text = $"Склад забит!";
            else
                InfoText[0].text = null;
            if (GameActive.PlayerInvent.ListOre2.Count >= ControlPar.AvailableSeats2)
                InfoText[1].text = $"Склад забит!";
            else if (GameActive.PlayerInvent.ListOre2.Count != 0)
                InfoText[1].text = null;
            else
                InfoText[1].text = $"Нет ресурсов!";

            if (GameActive.CreatureGold.ListCreatGold.Count >= ControlPar.AvailableSeatsGold)
                InfoText[2].text = $"Места на переработку заняты!";
            else if (GameActive.CreatureGold.ListCreatGold.Count != 0)
                InfoText[2].text = null;
            else
                InfoText[2].text = $"Нечего перерабатывать.";
            if (GameActive.PlayerInvent.ListInvent.Count >= ControlPar._InventoryAll)
                InfoText[3].text = $"Инвентарь полон!";
            else if (GameActive.PlayerInvent.ListInvent.Count <= ControlPar._InventoryAll)
                InfoText[3].text = null;
        }
    }
}