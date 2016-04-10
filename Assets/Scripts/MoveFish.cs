using UnityEngine;
using System.Collections;

public class MoveFish : MonoBehaviour {

    
    public float moveSpeed;
    public float revolutionSpeed;
    public float timeToSwim = 10;
    public float timeToSwimPlusMinus = 4;

    public int layerOfDome = 9;

    public AnimationCurve revolveToAttackCurve;

    public Transform targetForDomeCollision;

    public GameObject[] crackTypesToSpawn;

    private bool isMoving = true;

    private bool isColliding = false;

    //private GameObject parent;

    private float startedMoving = -1;

    //private Transform targetCrack;

    void Start()
    {
        targetForDomeCollision = GameObject.FindGameObjectWithTag("targetForDomeCollision").transform;
        /*
        parent = new GameObject();
        parent.transform.position = targetForDomeCollision.position;
        parent.transform.rotation = targetForDomeCollision.rotation;
        transform.parent = parent.transform;
        transform.rotation = Quaternion.identity;
        */

        if (startedMoving < 0)
        {
            startedMoving = Time.time;
        }

        timeToSwim += Random.Range(-timeToSwimPlusMinus, timeToSwimPlusMinus);

        //targetCrack = transform.GetChild(0);
    }

	// Update is called once per frame
	void Update () {
        if (isMoving)
        {
            
            //low curve value means revolution only, max curve x value means only moving towards screen. This should make a spiral.
            float animationRatio = revolveToAttackCurve.Evaluate((Time.time - startedMoving) / timeToSwim);

            float animRatioMinusOne = Mathf.Abs(animationRatio - 1);

            //transform.Translate((transform.position - targetForDomeCollision.position).normalized * moveSpeed * Time.deltaTime * animationRatio);
            //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, targetForDomeCollision.position, moveSpeed * Time.deltaTime * animationRatio);
            

            //TODO: Need to figure out how to make quick utility state machines
            transform.RotateAround(targetForDomeCollision.transform.position, Vector3.up, revolutionSpeed * Time.deltaTime * animRatioMinusOne);


            //speed by curve also
        }
        else if (isColliding)
        {
            

            //targetCrack.GetComponent<Collider>().enabled = true;
            //TODO: make this the eyes
            transform.LookAt(targetForDomeCollision);

            //GetComponent<Renderer>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);

            //TODO:
            //HERE WE RICOCHET FISH (instantiate)

            gameObject.layer = 0;

            
            isColliding = false;

            int which = Random.Range(0, crackTypesToSpawn.Length - 1);
            GameObject child = (GameObject)Instantiate(crackTypesToSpawn[which], transform.position, transform.rotation);
            child.transform.parent = transform;
        }

	}

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            //Debug.Log(contact.otherCollider.gameObject);
            if(contact.otherCollider.gameObject.layer == layerOfDome)
            {
                if (isMoving)
                {
                    isMoving = false;
                    isColliding = true;
                }
                return;
            }
        }
        

    }


}
