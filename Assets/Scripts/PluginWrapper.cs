using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PluginWrapper : MonoBehaviour {

    private AndroidJavaObject javaClass;
    public Text myText;
	public Text myText2;



	// Use this for initialization
	void Start () {
        javaClass = new AndroidJavaObject("com.example.vrlibrary.Keys");

		Physics.IgnoreLayerCollision(2, 8);
		Physics.IgnoreLayerCollision(10, 9);
	

	}
		
	bool cansnap;
	// Update is called once per frame
	void Update () {
		cansnap = snapzo.GetComponent<snap_allowed> ().snapallow;

		/*if (objectA.name == "Neptun") {
			szneptun.SetActive(true);
		} else {
			szneptun.SetActive(false);
		}
*/

		//für Aufgabe 2 jeweils die SnapZone des jeweiligen Stern aktiv setzen, wenn dieser gegriffen

    }


	public void leiser(){
		myText.text = "leiser";
	}

	public void lauter(){
		
	}


	public GameObject hand;
	public GameObject objectA;
	public Transform objectB;
	public bool angeschaut=false;

	public bool snapallowed;
	Vector3 npos;

	public void greifen(string ok){
		myText.text = "greifen"+ok;
		//myText.text = "lauter";
		if ((ok == "1") && (angeschaut == true)) {
			if (hand.transform.childCount == 0) {
				myText.text = "lauter";
				objectA.transform.position = objectB.position;
				objectA.transform.rotation = Quaternion.Euler(0,0,0);
				objectA.transform.parent = objectB;
				objectA.GetComponent<Rigidbody>().useGravity = false;
			
			}

			}
		else if ((ok == "1")&&(hand.transform.childCount == 1)){
			getpospointer ();

			npos.x = wpos.x;
			npos.z = wpos.z;
			npos.y = wpos.y+0.1f;
			objectA.transform.position = npos;
			hand.transform.DetachChildren ();
			objectA.GetComponent<Rigidbody> ().useGravity = true;

			if ((snapallowed = true)&&(objecttosnap==objectA)&&(cansnap == true)) {
				snap ();
			} else {
				if (GameObject.Find("DenebBall").name=="DenebBall") {
					objectA.GetComponent<Rigidbody> ().useGravity = false;
				} else {
					objectA.GetComponent<Rigidbody> ().useGravity = true;
				}
			}
		}
	}

	Scene szene;
	public GameObject snapzo;
	public GameObject objecttosnap;
	public GameObject snappos;
	bool enter=true;


	public void snap(){
		

	//	objectA.GetComponent<Rigidbody> ().useGravity = true;
		OnTriggerStay (snapzo.GetComponent<SphereCollider> ());

		if (objecttosnap.name == "Sonne") {
			objecttosnap.GetComponent<Rotation> ().isSnappedso = true;
			objectA.transform.rotation = Quaternion.Euler(0,0,0);

		}
			
	}



	void OnTriggerStay(Collider other)
	{
		if( (enter)&& (snapallowed)) {
			objectA.GetComponent<Rigidbody> ().useGravity = false;
			objectA.GetComponent<MeshCollider> ().enabled = false;
			objectA.transform.rotation = snappos.transform.rotation;
			objectA.transform.position = snappos.transform.position;
			objectA.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			objectA.transform.localScale = snappos.transform.localScale;




		} 
	}

	public void anschauen(){
		angeschaut = true;
	}

	public void wegschauen(){
		angeschaut = false;
	}

	public GameObject pointer;
	public Vector3 wpos;

	public void getpospointer(){
		wpos = pointer.GetComponent<GvrReticlePointer> ().CurrentRaycastResult.worldPosition;
	
	}

	GameObject oA;
	bool panelactive=false;
	public GameObject camera;
	public void infopanel(string oki) {
		if ((oki == "1")&&(hand.transform.childCount == 1)&&(panelactive == false)){
			oA = objectA.transform.Find ("PanelMenu").gameObject;
			oA.SetActive (true);
			panelactive = true;
			oA.transform.LookAt (camera.transform);
		
			
		} else	if ((panelactive == true)&&(hand.transform.childCount == 1)&&(oki == "1")){
			oA.SetActive (false);
			panelactive = false;




	}


		


	}



}
