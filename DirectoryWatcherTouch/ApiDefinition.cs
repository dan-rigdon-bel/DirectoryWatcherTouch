//
// ApiDefinition.cs
// DirectoryWatcherTouch
//
// Created by dan (dan@mcneel.com) on 1/18/2014
// Robert McNeel & Associates.
//
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;

namespace DirectoryWatcherTouch
{
	[Model, BaseType (typeof (NSObject))]
	public partial interface DirectoryWatcherDelegate {

		[Export ("directoryDidChange:")]
		void DirectoryDidChange (DirectoryWatcher folderWatcher);
	}

	[BaseType (typeof (NSObject))]
	public partial interface DirectoryWatcher {

		[Export ("delegate", ArgumentSemantic.Assign)]
		DirectoryWatcherDelegate Delegate { get; set; }

		[Static, Export ("watchFolderWithPath:delegate:")]
		DirectoryWatcher WatchFolderWithPath (string watchPath, DirectoryWatcherDelegate watchDelegate);

		[Export ("invalidate")]
		void Invalidate ();
	}
}

