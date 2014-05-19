using UnityEngine;
using System.IO;
using System.Collections;
using System;


/*
 * This is a public utility class with functions for sampling data related to in game user's joints.
 */
public class JointSampler {

	public bool init;

	private dbAccess db_control;
	private int active_user;

	public JointSampler() {
		init = true;
		db_control = new dbAccess ();
		active_user = PlayerPrefs.GetInt ("ActiveUser", 1);
	}

	/*
	 * Accept a GloveReader instance and store relevant values into the database
	 */
	public void SampleGloves(GloveReader reader, int user_id, string scene_name) {
		float [] values = reader.getValues ();
		float l_index = 0;
		float l_middle = 0;
		float l_ring = 0;
		float l_pinky = 0;
		float l_thumb = 0;
		float l_knuckle = 0;
		float r_index = values [reader.RH_IndexFinger ()];
		float r_middle = values [reader.RH_MiddleFinger ()];
		float r_ring = values [reader.RH_RingFinger ()];
		float r_pinky = values [reader.RH_PinkyFinger ()];
		float r_thumb = 0;
		float r_knuckle = values [reader.RH_Knuckle ()];

		float [] values_in = new float [] {
			l_index = 0,
			l_middle = 0,
			l_ring = 0,
			l_pinky = 0,
			l_thumb = 0,
			l_knuckle = 0,
			r_index = values [reader.RH_IndexFinger ()],
			r_middle = values [reader.RH_MiddleFinger ()],
			r_ring = values [reader.RH_RingFinger ()],
			r_pinky = values [reader.RH_PinkyFinger ()],
			r_thumb = 0,
			r_knuckle = values [reader.RH_Knuckle ()]
		};

		db_control.OpenDB();
		db_control.InsertTimeSeriesGloveData(active_user, scene_name, values_in);
		db_control.CloseDB();
	}

	/*
	 * This function will accept a ZigSkeleton instance and will extract world position and local rotation values for user joints.
	 * These angles will then be added as a row into a user's time series tables
	 * TODO: Create a way for the caller to be more specific about what joints to map
	 */
	public void SampleAllJoints(ZigSkeleton skel, int user_id, string scene_name, bool record_rotations = true, bool record_positions = true) {
		Vector3 r_shoulder_rot;
		Vector3 r_shoulder_pos;
		Vector3 r_elbow_rot;
		Vector3 r_elbow_pos;
		Vector3 r_wrist_rot;
		Vector3 r_wrist_pos;
		Vector3 r_hand_rot;
		Vector3 r_hand_pos;
		Vector3 l_shoulder_rot;
		Vector3 l_shoulder_pos;
		Vector3 l_elbow_rot;
		Vector3 l_elbow_pos;
		Vector3 l_wrist_rot;
		Vector3 l_wrist_pos;
		Vector3 l_hand_rot;
		Vector3 l_hand_pos;
		Vector3 head_rot;
		Vector3 head_pos;
		Vector3 neck_rot;
		Vector3 neck_pos;
		Vector3 l_collar_rot;
		Vector3 l_collar_pos;
		Vector3 r_collar_rot;
		Vector3 r_collar_pos;
		Vector3 torso_rot;
		Vector3 torso_pos;
		Vector3 waist_rot;
		Vector3 waist_pos;
		Vector3 l_hip_rot;
		Vector3 l_hip_pos;
		Vector3 r_hip_rot;
		Vector3 r_hip_pos;
		Vector3 l_knee_rot;
		Vector3 l_knee_pos;
		Vector3 r_knee_rot;
		Vector3 r_knee_pos;
		Vector3 l_ankle_rot;
		Vector3 l_ankle_pos;
		Vector3 r_ankle_rot;
		Vector3 r_ankle_pos;
		Vector3 l_foot_rot;
		Vector3 l_foot_pos;
		Vector3 r_foot_rot;
		Vector3 r_foot_pos;
		
		float [] rotation_values;
		float [] position_values;
		string query;
		
		if (record_rotations) {
			r_shoulder_rot = skel.GetJointLocalEulerAngles(ZigJointId.RightShoulder);
			l_shoulder_rot = skel.GetJointLocalEulerAngles(ZigJointId.LeftShoulder);
			r_elbow_rot = skel.GetJointLocalEulerAngles(ZigJointId.RightElbow);
			l_elbow_rot = skel.GetJointLocalEulerAngles(ZigJointId.LeftElbow);
			r_wrist_rot = skel.GetJointLocalEulerAngles(ZigJointId.RightWrist);
			l_wrist_rot = skel.GetJointLocalEulerAngles(ZigJointId.LeftWrist);
			l_hand_rot = skel.GetJointLocalEulerAngles(ZigJointId.LeftHand);
			r_hand_rot = skel.GetJointLocalEulerAngles(ZigJointId.RightHand);
			head_rot = skel.GetJointLocalEulerAngles(ZigJointId.Head);
			neck_rot = skel.GetJointLocalEulerAngles(ZigJointId.Neck);
			l_collar_rot = skel.GetJointLocalEulerAngles(ZigJointId.LeftCollar);
			r_collar_rot = skel.GetJointLocalEulerAngles(ZigJointId.RightCollar);
			torso_rot = skel.GetJointLocalEulerAngles(ZigJointId.Torso);
			waist_rot = skel.GetJointLocalEulerAngles(ZigJointId.Waist);
			l_hip_rot = skel.GetJointLocalEulerAngles(ZigJointId.LeftHip);
			r_hip_rot = skel.GetJointLocalEulerAngles(ZigJointId.RightHip);
			l_knee_rot = skel.GetJointLocalEulerAngles(ZigJointId.LeftKnee);
			r_knee_rot = skel.GetJointLocalEulerAngles(ZigJointId.RightKnee);
			l_ankle_rot = skel.GetJointLocalEulerAngles(ZigJointId.LeftAnkle);
			r_ankle_rot = skel.GetJointLocalEulerAngles(ZigJointId.RightAnkle);
			l_foot_rot = skel.GetJointLocalEulerAngles(ZigJointId.LeftFoot);
			r_foot_rot = skel.GetJointLocalEulerAngles(ZigJointId.RightFoot);
			
			rotation_values = new float[] {
				l_shoulder_rot.x,
				l_shoulder_rot.y,
				l_shoulder_rot.z,
				r_shoulder_rot.x,
				r_shoulder_rot.y,
				r_shoulder_rot.z,
				l_elbow_rot.x,
				l_elbow_rot.y,
				l_elbow_rot.z,
				r_elbow_rot.x,
				r_elbow_rot.y,
				r_elbow_rot.z,
				l_wrist_rot.x,
				l_wrist_rot.y,
				l_wrist_rot.z,
				r_wrist_rot.x,
				r_wrist_rot.y,
				r_wrist_rot.z,
				l_hand_rot.x,
				l_hand_rot.y,
				l_hand_rot.z,
				r_hand_rot.x,
				r_hand_rot.y,
				r_hand_rot.z,
				head_rot.x,
				head_rot.y,
				head_rot.z,
				neck_rot.x,
				neck_rot.y,
				neck_rot.z,
				l_collar_rot.x,
				l_collar_rot.y,
				l_collar_rot.z,
				r_collar_rot.x,
				r_collar_rot.y,
				r_collar_rot.z,
				torso_rot.x,
				torso_rot.y,
				torso_rot.z,
				waist_rot.x,
				waist_rot.y,
				waist_rot.z,
				l_hip_rot.x,
				l_hip_rot.y,
				l_hip_rot.z,
				r_hip_rot.x,
				r_hip_rot.y,
				r_hip_rot.z,
				l_knee_rot.x,
				l_knee_rot.y,
				l_knee_rot.z,
				r_knee_rot.x,
				r_knee_rot.y,
				r_knee_rot.z,
				l_ankle_rot.x,
				l_ankle_rot.y,
				l_ankle_rot.z,
				r_ankle_rot.x,
				r_ankle_rot.y,
				r_ankle_rot.z,
				l_foot_rot.x,
				l_foot_rot.y,
				l_foot_rot.z,
				r_foot_rot.x,
				r_foot_rot.y,
				r_foot_rot.z
			};
			db_control.OpenDB();
			db_control.InsertTimeSeriesRotations(active_user, scene_name, rotation_values);
			db_control.CloseDB();
		}
		
		if (record_positions) {
			r_shoulder_pos = skel.GetJointWorldPosition(ZigJointId.RightShoulder);
			l_shoulder_pos = skel.GetJointWorldPosition(ZigJointId.LeftShoulder);
			r_elbow_pos = skel.GetJointWorldPosition(ZigJointId.RightElbow);
			l_elbow_pos = skel.GetJointWorldPosition(ZigJointId.LeftElbow);
			r_wrist_pos = skel.GetJointWorldPosition(ZigJointId.RightWrist);
			l_wrist_pos = skel.GetJointWorldPosition(ZigJointId.LeftWrist);
			l_hand_pos = skel.GetJointWorldPosition(ZigJointId.LeftHand);
			r_hand_pos = skel.GetJointWorldPosition(ZigJointId.RightHand);
			head_pos = skel.GetJointWorldPosition(ZigJointId.Head);
			neck_pos = skel.GetJointWorldPosition(ZigJointId.Neck);
			l_collar_pos = skel.GetJointWorldPosition(ZigJointId.LeftCollar);
			r_collar_pos = skel.GetJointWorldPosition(ZigJointId.RightCollar);
			torso_pos = skel.GetJointWorldPosition(ZigJointId.Torso);
			waist_pos = skel.GetJointWorldPosition(ZigJointId.Waist);
			l_hip_pos = skel.GetJointWorldPosition(ZigJointId.LeftHip);
			r_hip_pos = skel.GetJointWorldPosition(ZigJointId.RightHip);
			l_knee_pos = skel.GetJointWorldPosition(ZigJointId.LeftKnee);
			r_knee_pos = skel.GetJointWorldPosition(ZigJointId.RightKnee);
			l_ankle_pos = skel.GetJointWorldPosition(ZigJointId.LeftAnkle);
			r_ankle_pos = skel.GetJointWorldPosition(ZigJointId.RightAnkle);
			l_foot_pos = skel.GetJointWorldPosition(ZigJointId.LeftFoot);
			r_foot_pos = skel.GetJointWorldPosition(ZigJointId.RightFoot);
			
			position_values = new float[] {
				l_shoulder_pos.x,
				l_shoulder_pos.y,
				l_shoulder_pos.z,
				r_shoulder_pos.x,
				r_shoulder_pos.y,
				r_shoulder_pos.z,
				l_elbow_pos.x,
				l_elbow_pos.y,
				l_elbow_pos.z,
				r_elbow_pos.x,
				r_elbow_pos.y,
				r_elbow_pos.z,
				l_wrist_pos.x,
				l_wrist_pos.y,
				l_wrist_pos.z,
				r_wrist_pos.x,
				r_wrist_pos.y,
				r_wrist_pos.z,
				l_hand_pos.x,
				l_hand_pos.y,
				l_hand_pos.z,
				r_hand_pos.x,
				r_hand_pos.y,
				r_hand_pos.z,
				head_pos.x,
				head_pos.y,
				head_pos.z,
				neck_pos.x,
				neck_pos.y,
				neck_pos.z,
				l_collar_pos.x,
				l_collar_pos.y,
				l_collar_pos.z,
				r_collar_pos.x,
				r_collar_pos.y,
				r_collar_pos.z,
				torso_pos.x,
				torso_pos.y,
				torso_pos.z,
				waist_pos.x,
				waist_pos.y,
				waist_pos.z,
				l_hip_pos.x,
				l_hip_pos.y,
				l_hip_pos.z,
				r_hip_pos.x,
				r_hip_pos.y,
				r_hip_pos.z,
				l_knee_pos.x,
				l_knee_pos.y,
				l_knee_pos.z,
				r_knee_pos.x,
				r_knee_pos.y,
				r_knee_pos.z,
				l_ankle_pos.x,
				l_ankle_pos.y,
				l_ankle_pos.z,
				r_ankle_pos.x,
				r_ankle_pos.y,
				r_ankle_pos.z,
				l_foot_pos.x,
				l_foot_pos.y,
				l_foot_pos.z,
				r_foot_pos.x,
				r_foot_pos.y,
				r_foot_pos.z
			};
			db_control.OpenDB();
			db_control.InsertTimeSeriesPositions(active_user, scene_name, position_values);
			db_control.CloseDB();
		}
	}
}
