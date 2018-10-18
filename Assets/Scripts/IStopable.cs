using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStopable
{
    bool Stoped { get; set; }
	void Stop ();
}