using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BoundaryScript : MonoBehaviour
{
	private void OnTriggerExit2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}
}
