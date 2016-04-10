using System;
using UnityEngine;

namespace VRStandardAssets.Utils
{
    // This class should be added to any gameobject in the scene
    // that should react to input based on the user's gaze.
    // It contains events that can be subscribed to by classes that
    // need to know about input specifics to this gameobject.
    public class VRInteractiveItem : MonoBehaviour
    {
        public event Action OnOver;             // Called when the gaze moves over this object
        public event Action OnOut;              // Called when the gaze leaves this object
        public event Action OnClick;            // Called when click input is detected whilst the gaze is over this object.
        public event Action OnDoubleClick;      // Called when double click input is detected whilst the gaze is over this object.
        public event Action OnUp;               // Called when Fire1 is released whilst the gaze is over this object.
        public event Action OnDown;             // Called when Fire1 is pressed whilst the gaze is over this object.


        protected bool m_IsOver;



        private float tapDownBeginTime;
        private bool beganHold = false;


        public bool IsOver
        {
            get { return m_IsOver; }              // Is the gaze currently over this object?
        }


        // The below functions are called by the VREyeRaycaster when the appropriate input is detected.
        // They in turn call the appropriate events should they have subscribers.
        public void Over()
        {
            m_IsOver = true;

            if (OnOver != null)
            {

                if (tag == Patch.Instance.tagToFix)
                {
                    if (!beganHold && Input.GetButton("Fire1"))
                    {
                        Debug.Log("BEGAN HOLD TRUE");
                        tapDownBeginTime = Time.time;
                        beganHold = true;
                    }


                }

                OnOver();

                
            }
        }

        void Update()
        {
            if (tag == Patch.Instance.tagToFix)
            {
                //if(beganHold)
                //Debug.Log("beganTap: " + beganHold + "; tapDownBeginTime: " + tapDownBeginTime + "; Time.time - tapDownBeginTime: " + (Time.time - tapDownBeginTime) + "; Patch.Instance.timeToFix: " + Patch.Instance.timeToFix);

                if ((beganHold ) && Time.time - tapDownBeginTime > Patch.Instance.timeToFix)
                {

                    if (OnDown != null)
                    {
                        OnDown();
                    }
                    beganHold = false;
                }

                //TODO: sparse calls, like on move
                //Patch.Instance.UpdateLineRendererOnTarget(Vector3.zero);

               

                
            }
            
        }

        public void Out()
        {
            m_IsOver = false;

            if (OnOut != null)
                OnOut();

            beganHold = false;
        }


        public void Click()
        {
            if (OnClick != null)
                OnClick();

            beganHold = false;
        }


        public void DoubleClick()
        {
            if (OnDoubleClick != null)
                OnDoubleClick();

            beganHold = false;
        }


        public void Up()
        {
            if (OnUp != null)
                OnUp();

            beganHold = false;
        }


        public void Down()
        {
            
            if (OnDown != null)
            {
                
                if (tag == Patch.Instance.tagToFix)
                {
                    if (!beganHold)
                    {
                        Debug.Log("BEGAN HOLD TRUE");
                        tapDownBeginTime = Time.time;
                        beganHold = true;
                    }

                    
                }
                else
                {
                    Patch.Instance.UpdateLineRenderer(Vector3.zero);
                    OnDown();
                }
            }
        }
    }
}