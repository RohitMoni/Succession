using System.Collections;
using UnityEngine;

namespace Assets.Code
{
    public class InformationManager : MonoBehaviour {

        // private references set in code
        private GameObject _informationPanel;

        // member variables
        private bool _informationPanelActive;
        private Coroutine _informationPanelSlideCoroutine;

        // constants
        private readonly float _activeInformationPanelPosition = Screen.width * 0.5f;
        private readonly float _inactiveInformationPanelPosition = -Screen.width * 0.5f;

        void Awake()
        {
            _informationPanel = GameObject.Find("InformationPanel");
        }

        // Use this for initialization
        void Start () {
            _informationPanelActive = false;
            _informationPanelSlideCoroutine = null;
        }
	
        // Update is called once per frame
        void Update () {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ToggleInformationPanel();
            }
#endif
        }

        public void ToggleInformationPanel()
        {
            _informationPanelActive = !_informationPanelActive;

            if (_informationPanelSlideCoroutine != null)
                StopCoroutine(_informationPanelSlideCoroutine);

            _informationPanelSlideCoroutine = (_informationPanelActive ? 
                StartCoroutine(SlideInformationPanel(_informationPanel.transform.position.x, _activeInformationPanelPosition, GameManager.PanelSlideTime)) : 
                StartCoroutine(SlideInformationPanel(_informationPanel.transform.position.x, _inactiveInformationPanelPosition, GameManager.PanelSlideTime)));
        }

        IEnumerator SlideInformationPanel(float startXPosition, float finalXPosition, float time)
        {
            var timer = 0f;
            var position = _informationPanel.transform.position;
            while (timer < time)
            {
                timer += Time.smoothDeltaTime;

                position.x = Mathf.Lerp(startXPosition, finalXPosition, Mathf.SmoothStep(0, 1, timer / time));
                _informationPanel.transform.position = position;
                yield return null;
            }

            position.x = finalXPosition;
            _informationPanel.transform.position = position;

            yield return null;
        }

    }
}
