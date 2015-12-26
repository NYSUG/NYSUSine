### NYSUSine.cs tool for using sinewaves
This utility was developed for my game Atomic Space Command. Check it out: http://atomicspacecommand.net

### Usage

In order to simplify and make using sine waves across a game use this utility. Here's how to use it.

The utility provides tools to create sine waves of different amplitudes and periods. It also gives you access to the games global sinewave. First declare four variables for the sinewave.

    public float pulseSineAmplitude = 5.0f;
    public float pulseSinePeriod = 3.0f;
    private bool _shouldPuseImage;
    private string _pulseSineRequestGuid = string.Empty;

Next you will need to create a sinewave request with your amplitude and period:

    _pulseSineRequestGuid = NYSUSine.AddSinWaveRequestor (pulseSineAmplitude, pulseSinePeriod);

Then you will need to write a method that will apply the sinewave to a movement or value:

    private void PulseImage ()
	{
		Color color = blinkImage.color;
		color.a = NYSUSine.GetSinWave (_pulseSineRequestGuid);

		blinkImage.color = color;
	}

Finally you will need to add a call to the method from the update loop:

    private void Update ()
    {
      if (_shouldPuseImage) {
        PulseImage ();
		  }
	  }
