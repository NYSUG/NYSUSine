/******************
The MIT License (MIT)
Copyright (c) 2015 No, You Shut Up Inc.
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, 
modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the 
Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
********************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NYSUSine : MonoBehaviour {

	// Struct for our SinWave values
	private class SinWave 
	{
		public float amplitude;
		public float period;
	}

	// Storage for our SinWaves
	private static Dictionary<string, SinWave> _sinWaveValues = new Dictionary<string, SinWave> ();

#region Adding/Removing Sin requestors
	
	public static string AddSinWaveRequestor (float amplitude, float period)
	{
		string guid = System.Guid.NewGuid ().ToString ();
		SinWave sinWave = new SinWave () {
			amplitude = amplitude,
			period = period,
		};
		
		_sinWaveValues.Add (guid, sinWave);
		return guid;
	}
	
	public static void RemoveSinWaveRequestor (string guid)
	{
		if (!_sinWaveValues.ContainsKey (guid)) {
			Debug.LogWarning (string.Format ("No key found for {0}", guid));
			return;
		}
		
		_sinWaveValues.Remove (guid);
	}
	
#endregion

#region Sin Waves

	// This is the base sinewave gauranteed to be uniform for all components
	public static float GetGlobalSinWave ()
	{
		return Mathf.Sin(Time.timeSinceLevelLoad);
	}
	
	public static float GetSinWave (string guid)
	{
		if (!_sinWaveValues.ContainsKey (guid)) {
			Debug.LogWarning (string.Format ("No key found for {0}", guid));
			return 0f;
		}
		
		float theta = Time.timeSinceLevelLoad / _sinWaveValues [guid].period;
		return _sinWaveValues [guid].amplitude * Mathf.Sin(theta);
	}
	
#endregion

}
