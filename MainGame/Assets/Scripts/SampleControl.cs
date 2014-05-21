using UnityEngine;
using System.Collections;

public class SampleControl : MonoBehaviour {

	public bool record_joint_data = true;	
	public bool record_glove_data = true;	
	public float capture_rate = 0.1f;

	private JointSampler sampler;
	private GameObject zigfu;
	private Zig zig_control;
	private ZigSkeleton skeleton;
	private GloveReader reader;
	private dbAccess db_control;
	private int user_id;
	private float time_old = 0.0f;
	private float time_new = 0.0f;
	private float time_diff = 0.0f;

	// Use this for initialization
	void Start () {
		sampler = new JointSampler ();
		user_id = PlayerPrefs.GetInt ("ActiveUser", 1);
		// Load ZigFu game object.  This game object has 4 Zig related script Components.  Use this object
		// to instances of these script's classes in order to access event information :)
		zigfu = GameObject.Find ("ZigFu");
		zig_control = zigfu.GetComponent <Zig>();
		skeleton = GetComponent <ZigSkeleton>();
		db_control = new dbAccess ();
		reader = new GloveReader ();
	}
	
	// Update is called once per frame
	void Update () {
		time_new += Time.deltaTime;
		time_diff = time_new - time_old;
		
		if (time_diff >= capture_rate) {
			// Update old time 
			time_old = time_new;
			// Check to make sure one user is actually in the Kinect's view
			if (zig_control.usersInView == 1) {
				if (record_joint_data)
					sampler.SampleAllJoints(skeleton, user_id, db_control.cylinder_reach_scene, record_rotations : record_joint_data, record_positions : record_joint_data);
				if (record_glove_data)
					sampler.SampleGloves(reader, user_id, db_control.cylinder_reach_scene);
			}
		}
	}
}
