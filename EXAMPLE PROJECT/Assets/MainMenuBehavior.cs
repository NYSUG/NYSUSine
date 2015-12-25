using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuBehavior : MonoBehaviour {

	public Image blinkImage;
	public Image moveImage;

	// Power Animation
	public float pulseSineAmplitude = 5.0f;
	public float pulseSinePeriod = 3.0f;

	private bool _shouldPuseImage;
	private string _pulseSineRequestGuid = string.Empty;

	private bool _shouldMoveImage;

	public void PulseButtonPressed ()
	{
		if (_shouldPuseImage) {
			// Turn it off
			NYSUSine.RemoveSinWaveRequestor (_pulseSineRequestGuid);
			_pulseSineRequestGuid = string.Empty;
		} else {
			// Turn it on
			_pulseSineRequestGuid = NYSUSine.AddSinWaveRequestor (pulseSineAmplitude, pulseSinePeriod);
		}

		_shouldPuseImage = !_shouldPuseImage;
	}

	public void MoveButtonPressed ()
	{
		// Movement uses the global sinewave
		_shouldMoveImage = !_shouldMoveImage;
	}

	private void Update ()
	{
		if (_shouldPuseImage) {
			PulseImage ();
		}

		if (_shouldMoveImage) {
			MoveImage ();
		}
	}

	private void PulseImage ()
	{
		Color color = blinkImage.color;
		color.a = NYSUSine.GetSinWave (_pulseSineRequestGuid);

		blinkImage.color = color;
	}

	private void MoveImage ()
	{
		moveImage.transform.localPosition = new Vector3 (-350f * NYSUSine.GetGlobalSinWave (), -150f, 0);
	}
}
