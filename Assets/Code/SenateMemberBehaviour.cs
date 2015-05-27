using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class SenateMemberBehaviour : MonoBehaviour {

        // External references
        private Transform _senateMembersAnchor;

        // Internal references
        private Button _button;
        private Slider _supportMeter;

        // Member variables
        public float Support;

        // Constants
        private const float MaximumSupport = 1f;

        void Awake()
        {
            _senateMembersAnchor = GameObject.Find("SenateMembersAnchor").transform;
            _button = GetComponent<Button>();
            _supportMeter = transform.FindChild("SupportMeter").GetComponent<Slider>();
        }

        // Use this for initialization
        void Start () {
            Initialise();
        }

        // Update is called once per frame
        void Update () {
	
        }

        public void Initialise()
        {
            name = "SenateMember";
            transform.SetParent(_senateMembersAnchor);
            transform.localScale = Vector3.one;
            _button.interactable = true;
            Support = 0;

            _button.onClick.AddListener(Clicked);
        }

        void Clicked()
        {
            IncrementSupport();
        }

        public void IncrementSupport()
        {
            Support += 0.1f;
            _supportMeter.value = Support;
        }
    }
}
