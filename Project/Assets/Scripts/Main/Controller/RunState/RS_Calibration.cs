﻿using UnityEngine;
using System.Collections;
using com.erik.util;
using com.erik.training.model;
using com.erik.training.view;

namespace com.erik.training.controller{

	public class RS_Calibration : RunState {
		
		// Use this for initialization
		void Start () {

			ViewController.OnReady += HandleOnCalibrationViewReady;
			ViewController.Instance.SetViewState (ViewState.VS_CALIBRATION);
		}		

		private void HandleOnCalibrationViewReady()
		{
			ViewController.OnReady -= HandleOnCalibrationViewReady;

			CalibrationView.OnGoHome += HandleOnGoHome;
			CalibrationView.OnCalibrationSuccess += HandleOnCalibrationSuccess;		
		}

		void HandleOnCalibrationSuccess ()
		{
			CalibrationView.OnCalibrationSuccess -= HandleOnCalibrationSuccess;
			CalibrationView.OnGoHome -= HandleOnGoHome;

			nextState = typeof(RS_Exercise);
			GoNext ();
		}

		private void HandleOnGoHome()
		{
			CalibrationView.OnCalibrationSuccess -= HandleOnCalibrationSuccess;
			CalibrationView.OnGoHome -= HandleOnGoHome;

			nextState = typeof(RS_Home);
			GoNext ();
		}	

	}

}
