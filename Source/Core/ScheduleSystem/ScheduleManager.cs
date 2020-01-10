// Copyright 2019. All Rights Reserved.
using System;
using System.Collections.Generic;
using Backend.Base.ScheduleSystem;
using Backend.Core.LogSystem;
using GameFramework.Common.MemoryManagement;
using GameFramework.Common.Timing;

namespace Backend.Core.ScheduleSystem
{
	class ScheduleManager : Singleton<ScheduleManager>, IService, IScheduleManager
	{
		private class ActionInfo
		{
			public Action Action
			{
				get;
				private set;
			}

			public double DoTime
			{
				get;
				private set;
			}

			public ActionInfo(Action Action, double DoTime)
			{
				this.Action = Action;
				this.DoTime = DoTime;
			}
		}

		private class ActionInfoList : List<ActionInfo>
		{ }

		private ActionInfoList mainThreadActions = null;

		public void Initialize()
		{
			mainThreadActions = new ActionInfoList();
		}

		public void Service()
		{
			for (int i = 0; i < mainThreadActions.Count; ++i)
			{
				ActionInfo info = mainThreadActions[i];

				if (Time.CurrentEpochTime < info.DoTime)
					continue;

				try
				{
					info.Action();
				}
				catch (Exception e)
				{
					LogManager.Instance.WriteException(e, "Main thread scheduler failed to invoke callback");
				}

				mainThreadActions.RemoveAt(i--);
			}
		}

		public void Shutdown()
		{
			mainThreadActions.Clear();
		}

		public void ScheduleMMainThread(Action Action, float Delay)
		{
			mainThreadActions.Add(new ActionInfo(Action, Time.CurrentEpochTime + Delay));
		}
	}
}