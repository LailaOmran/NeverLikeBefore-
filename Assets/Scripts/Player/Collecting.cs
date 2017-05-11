using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : PlayerBehaviors {
	public bool startCollectingAnim = true;
	public bool isSuffocated =  true;
	private GameObject[] collectableObjects;


	private void Update() {
		bool q = Input.GetKeyDown (KeyCode.Q);

		if (q) {
			/*if (objColCheck.canCollect) {
				UncollectObject ();	
				objColCheck.canCollect = false;
			}
			else*/
			startCollectingAnim = true;
		} 
	}


	public void CollectObject () {
		collectableObjects = GameObject.FindGameObjectsWithTag ("Collectables");

		foreach (var rock in collectableObjects) {
			if (rock.GetComponent<ObjectCollisionChecking>().canCollect) {
				
				if (rock.name == "Mask") {
					isSuffocated = false;
					rock.transform.SetParent (this.transform.GetChild (5).GetChild (2).GetChild (0).GetChild (0).GetChild (0));
				}
				else
					rock.transform.SetParent (rock.GetComponent<ObjectCollisionChecking>().colliderOfPivot.gameObject.transform);

				rock.transform.localPosition = Vector3.zero;
				rock.transform.localRotation = Quaternion.identity;
			}
		}
	}


	/*private void UncollectObject () {
	}*/
}
