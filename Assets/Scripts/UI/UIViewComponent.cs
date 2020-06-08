using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Itorum
{
    public class UIViewComponent : MonoBehaviour
    {
        public Button PrepareBtn;
        public Button FireBtn;

        public GameObject ViewBtnsContainer;

        public Button PlayerViewBtn;
        public Button RocketViewBtn;
        public Button RemoteViewBtn;

        public Color ActiveBtnColor = Color.green;
        public Color InactiveBtnColor = Color.white;

        public Text HitSuccessTxt;

        public Button RestartBtn;
    }
}