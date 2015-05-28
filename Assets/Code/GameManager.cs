using System.Collections;
using UnityEngine;

namespace Assets.Code
{
    public class GameManager : MonoBehaviour
    {
        // private references set in code
        private SenateManager _senateManager;
        private GameObject _decisionPanel;
        
        // member variables

        // constants
        public static float PanelSlideTime = 0.5f;

        void Awake()
        {
            _senateManager = GetComponent<SenateManager>();
            _decisionPanel = GameObject.Find("DecisionPanel");
        }

        // Use this for initialization
        void Start ()
        {
        }
	
        // Update is called once per frame
        void Update () {

        }
            
        public void CoupButtonPressed()
        {
            if (_senateManager.CoupIsSuccessful())
            {
                Application.LoadLevel("EndGameScene");
            }
            else
            {
                
            }
        }
    }
}
