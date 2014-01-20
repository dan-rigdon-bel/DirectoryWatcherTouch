//
// DirectoryChangedDelegate.cs
// DirectoryWatcherTouch
//
// Created by dan (dan@mcneel.com) on 1/18/2014
// Robert McNeel & Associates.
//
using System;

namespace DirectoryWatcherTouch
{

	public interface IDirectoryWatcher
	{
		void OnChanged (DirectoryWatcherTouch.DirectoryWatcher folderWatcher);
	}

	public class DirectoryChangedDelegate:DirectoryWatcherDelegate
	{
		private readonly IDirectoryWatcher m_watcher;

		public DirectoryChangedDelegate (IDirectoryWatcher watcher) {
			m_watcher = watcher;
		}

		public override void DirectoryDidChange (DirectoryWatcherTouch.DirectoryWatcher folderWatcher)
		{
			if (m_watcher != null)
				m_watcher.OnChanged (folderWatcher);
		}
	}
}

