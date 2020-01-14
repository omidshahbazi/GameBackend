// Copyright 2019. All Rights Reserved.
namespace Backend.Base.ConfigSystem
{
	public interface IConfigManager
	{
		bool LoadConfig<T>(string FilePath, out T Config);
		bool SaveConfig<T>(T Config);
	}
}