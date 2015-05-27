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
        private bool _decisionPanelActive;
        private Coroutine _decisionPanelSlideCoroutine;

        // constants
        private const float PanelSlideTime = 0.5f;

        void Awake()
        {
            _senateManager = GetComponent<SenateManager>();
            _decisionPanel = GameObject.Find("DecisionPanel");
        }

        // Use this for initialization
        void Start ()
        {
            _decisionPanelActive = false;
            _decisionPanelSlideCoroutine = null;
        }
	
        // Update is called once per frame
        void Update () {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ToggleDecisionPanel();
            }
#endif
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

        public void ToggleDecisionPanel()
        {
            _decisionPanelActive = !_decisionPanelActive;

            if (_decisionPanelSlideCoroutine != null)
                StopCoroutine(_decisionPanelSlideCoroutine);

            _decisionPanelSlideCoroutine = (_decisionPanelActive ? StartCoroutine(SlideDecisionPanel(_decisionPanel.transform.position.x, Screen.width * 0.5f, PanelSlideTime)) : StartCoroutine(SlideDecisionPanel(_decisionPanel.transform.position.x, Screen.width * 1.5f, PanelSlideTime)));
        }

        IEnumerator SlideDecisionPanel(float startXPosition, float finalXPosition, float time)
        {
            var timer = 0f;
            var position = _decisionPanel.transform.position;
            while (timer < time)
            {
                timer += Time.smoothDeltaTime;

                position.x = Mathf.Lerp(startXPosition, finalXPosition, Mathf.SmoothStep(0, 1, timer/time));
                _decisionPanel.transform.position = position;
                yield return null;
            }

            position.x = finalXPosition;
            _decisionPanel.transform.position = position;

            yield return null;
        }
    }
}
