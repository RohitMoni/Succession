using System.Collections;
using UnityEngine;

namespace Assets.Code
{
    public class DecisionManager : MonoBehaviour {

        // private references set in code
        private GameObject _decisionPanel;

        // member variables
        private bool _decisionPanelActive;
        private Coroutine _decisionPanelSlideCoroutine;

        // constants
        private readonly float _activeDecisionPanelPosition = Screen.width*0.5f;
        private readonly float _inactiveDecisionPanelPosition = Screen.width*1.5f;

        void Awake()
        {
            _decisionPanel = GameObject.Find("DecisionPanel");
        }

        // Use this for initialization
        void Start () {
            _decisionPanelActive = false;
            _decisionPanelSlideCoroutine = null;
        }
	
        // Update is called once per frame
        void Update () {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ToggleDecisionPanel();
            }
#endif
        }

        public void ToggleDecisionPanel()
        {
            _decisionPanelActive = !_decisionPanelActive;

            if (_decisionPanelSlideCoroutine != null)
                StopCoroutine(_decisionPanelSlideCoroutine);

            _decisionPanelSlideCoroutine = (_decisionPanelActive ? 
                StartCoroutine(SlideDecisionPanel(_decisionPanel.transform.position.x, _activeDecisionPanelPosition, GameManager.PanelSlideTime)) : 
                StartCoroutine(SlideDecisionPanel(_decisionPanel.transform.position.x, _inactiveDecisionPanelPosition, GameManager.PanelSlideTime)));
        }

        IEnumerator SlideDecisionPanel(float startXPosition, float finalXPosition, float time)
        {
            var timer = 0f;
            var position = _decisionPanel.transform.position;
            while (timer < time)
            {
                timer += Time.smoothDeltaTime;

                position.x = Mathf.Lerp(startXPosition, finalXPosition, Mathf.SmoothStep(0, 1, timer / time));
                _decisionPanel.transform.position = position;
                yield return null;
            }

            position.x = finalXPosition;
            _decisionPanel.transform.position = position;

            yield return null;
        }

    }
}
