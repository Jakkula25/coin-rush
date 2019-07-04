using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


   








/* private void OnTriggerEnter(Collider other)
 {
     // score++;
     if (other.gameObject.tag == "enemy")
     {

         Time.timeScale = 0;
         // gameover.text = "gameover";

         Debug.Log("game over");
     }

 }*/


namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        public int newspeed = 2;
        int z;
        GameObject platform;
        GameObject platform2;
        int kill;
        public bool alive;
        public float speed;
        public Text countText;
       
        public Text timerText;
        public float time ;
        public static int fake;
        bool keepCounting;
        bool keepTiming ;
        public static int count;
       // public AudioClip impact;

        // Start is called before the first frame update
        void Start()
            {
            fake = 0;
            alive = true;
            z = 0;
            kill = 0;
            count = 0;
            time = 240;
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
           
                SetCountText();
            StartCoundownTimer();
           // winText.text = "";
            }

            // Update is called once per frame
            void Update()
            {

            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            

            if (keepTiming)
            {
                UpdateTimer();
            }
            if (keepCounting)
            {
                SetCountText();
            }

        }
        void StartCoundownTimer()
        {
            if (timerText != null)
            {
                time = 240;
                timerText.text = "Time Left: 04:00";
                InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
            }
        }
        void OnTriggerEnter(Collider other)
            {
                if (other.gameObject.CompareTag("Pick Up"))
                {
                
                //AudioSource.PlayClipAtPoint(impact, transform.position);
               
                Destroy(other.gameObject);
                    count = count + 1;
                    SetCountText();
                }
            if (other.gameObject.tag == "trigger")
            {
                
                if (kill > 2)
                {
                    Destroy(platform2);
                }

                z = z + 30;
                platform2 = platform;

                platform = (GameObject)Instantiate(Resources.Load("level"), new Vector3(0, 0, z), Quaternion.identity);
                //Instantiate(Resources.Load("Pick Up"), new Vector3(UnityEngine.Random.Range(30f, 1.8f), 0, UnityEngine.Random.Range(z, z + 59)), Quaternion.identity);
                kill++;
                Debug.Log("counter");
            }

        }
        void UpdateTimer()
        {
            if (timerText != null)
            {
                GameOver();

                if (time != 0)
                {


                    time -=  Time.deltaTime;
                    string minutes = Mathf.Floor(time / 60).ToString("00");
                    string seconds = (time % 60).ToString("00");
                    //string fraction = ((time * 100) % 100).ToString("000");
                    timerText.text = minutes + ":" + seconds;
                }
                
            }
        }
        void SetCountText()
            {
                countText.text = count.ToString();
                if (count == 100)
                {
                keepTiming = false;

                //winText.text = "You Win!";
                this.gameObject.GetComponent<ThirdPersonUserControl>().alive = false; 
                Time.timeScale = 0;
                timerText = null;
                keepCounting = false;
                //countText = null;
                
            }
            }
          void  GameOver()
        {
            if (timerText.text == "00:00")
            {
                fake = 1;
                keepTiming = false;
               // winText.text = "GAMEOVER";
                alive = false;
                timerText = null;
                Time.timeScale = 0;
            }
        }
        

        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.


        

       


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
