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
                InfoText[0].text = $"����� �����!";
            else
                InfoText[0].text = null;
            if (GameActive.PlayerInvent.ListOre2.Count >= ControlPar.AvailableSeats2)
                InfoText[1].text = $"����� �����!";
            else if (GameActive.PlayerInvent.ListOre2.Count != 0)
                InfoText[1].text = null;
            else
                InfoText[1].text = $"��� ��������!";

            if (GameActive.CreatureGold.ListCreatGold.Count >= ControlPar.AvailableSeatsGold)
                InfoText[2].text = $"����� �� ����������� ������!";
            else if (GameActive.CreatureGold.ListCreatGold.Count != 0)
                InfoText[2].text = null;
            else
                InfoText[2].text = $"������ ��������������.";
            if (GameActive.PlayerInvent.ListInvent.Count >= ControlPar._InventoryAll)
                InfoText[3].text = $"��������� �����!";
            else if (GameActive.PlayerInvent.ListInvent.Count <= ControlPar._InventoryAll)
                InfoText[3].text = null;
        }
    }
}