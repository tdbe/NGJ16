using UnityEngine;
using System.Collections;


public class HoverOverDome : MonoBehaviour {

    [SerializeField]
    private VRStandardAssets.Utils.VRInput m_VRInput;

    private VRStandardAssets.Utils.VRInteractiveItem m_InteractiveItem;

    private void OnEnable()
    {
        m_VRInput.OnDown += HandleDown;
        m_VRInput.OnUp += HandleUp;

        m_InteractiveItem.OnOver += HandleOver;
        //m_InteractiveItem.OnOut += HandleOut;
    }


    private void OnDisable()
    {
        m_VRInput.OnDown -= HandleDown;
        m_VRInput.OnUp -= HandleUp;

        m_InteractiveItem.OnOver -= HandleOver;
        //m_InteractiveItem.OnOut -= HandleOut;
    }

    private void HandleDown()
    {

    }

    private void HandleUp()
    {

    }

    private void HandleOver()
    {

    }

    private void HandleOut()
    {

    }

    // Use this for initialization
    void Start () {
        m_InteractiveItem = GetComponent<VRStandardAssets.Utils.VRInteractiveItem>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
