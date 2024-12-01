//Script by JosephHocking located at https://github.com/jhocking/uia-3e/blob/main/ch11/Assets/Scripts/Managers/IGameManager.cs
// Modified by Rob Garner (rgarner011235@gmail.com)

﻿public interface IGameManager {
	ManagerStatus status {get;}

	void Startup(NetworkService service);
}
