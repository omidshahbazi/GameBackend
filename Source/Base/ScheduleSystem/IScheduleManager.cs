// Copyright 2019. All Rights Reserved.
using System;

namespace Backend.Base.ScheduleSystem
{
	public interface IScheduleManager
	{
		void ScheduleMMainThread(Action Action, float Delay);
	}
}