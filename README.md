DirectoryWatcherTouch
=========================
A C# MonoTouch wrapper and binding around the Objective-C DirectoryWatcher class by Apple. This small library allow you to watch for change events to a Directory - the /Documents folder, for example.  DirectoryWatcherTouch provides a subset of the functionality of the C# .NET [FileSystemWatcher](http://msdn.microsoft.com/en-us/library/System.IO.FileSystemWatcher) class.
	
Pre-requisites
--------------------
You are going to need:

* [Apple Xcode](http://developer.apple.com/xcode/)
* [Xamarin.iOS](http://xamarin.com/ios)
* [Xamarin Studio](http://xamarin.com/studio) or [Visual Studio Professional](http://msdn.microsoft.com/vstudio) with Xamarin extensions.

Installation / Configuration
----------------------------
1.  Clone or download this repository to your Mac running OSX.  Place it in a convenient location such as _Development/Repositories/DirectoryWatcherTouch_ or similar. 
2.  Build the native, static _libDirectoryWatcher.a_ library.  Open a terminal window and navigate to the _DirectoryWatcherTouch/DirectoryWatcherNative/DirectoryWatcher_ folder.  (This folder contains a bash shell script for building the native library for the _iphonesimulator_, _armv7_ and _armv7s_.  These three architectures are bundled into single FAT binary using the lipo tool - see note below)  Simply run the following command at the prompt:
    
	sudo ./build_mobile.sh
    
3.  Once the static library has successfully built, you need to point the .NET binding project (_DirectoryWatcherTouch_) to the correct location.  In [Xamarin Studio](http://xamarin.com/studio) or [Visual Studio](http://msdn.microsoft.com/vstudio), open the _DirectoryWatcherTouch_ Solution contained in the _DirectoryWatcherTouch/DirectoryWatcherTouch_ folder.  The link to _libDirectoryWatcher.a_ may be broken and you will have to re-reference this file into the project.
4.  Clean and Build the _DirectoryWatcherTouch_ project.  The resulting _DirectoryWatcherTouch.dll_ that can be referenced into your project.

Usage
----------------------------
Set up a file system watcher...

	// Start watching the Documents folder...
	string documentsFolder = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
	var DocumentsDirectoryWatcher = new FileSystemWatcherTouch (documentsFolder);
	DocumentsDirectoryWatcher.Changed += OnDirectoryDidChange;

Handle change event callbacks...

	public void OnDirectoryDidChange (object sender, EventArgs args) {
		Console.WriteLine ("Change detected in the Documents folder");
		// Handle the change...
	}

Make sure you clean up after yourself when done...for example, in AppDelegate you might:

	public override void WillTerminate (UIApplication application)
	{
		base.WillTerminate (application);

		// Stop watching the Documents folder...
		DocumentsDirectoryWatcher.Changed -= OnDirectoryDidChange;
		DocumentsDirectoryWatcher.Dispose (); // This calls Invalidate() on the native watcher.
	}

Detailed Info
----------------------------
The native DirectoryWatcher class comes from this [Apple iOS Developer Library sample](https://developer.apple.com/library/ios/samplecode/DocInteraction/Listings/Classes_DirectoryWatcher_h.html).  This class uses the low-level _kqueue_ kernel event notification system.  The MonoTouch bindings wrapping this small library attempt (in a small way) to mimic Microsoft .NET [FileSystemWatcher](http://msdn.microsoft.com/en-us/library/System.IO.FileSystemWatcher) class, though only the _Changed_ event is current implemented.

* Note on the Static Binary
----------------------------
The build script (build_mobile.sh) included here builds a FAT binary targeting _iphonesimulator_, _armv7_, and _armv7s_.  To make the binary slightly smaller for release, you may remove the _iphonesimulator_ target.  Regardless, the FAT binary is quite small, so it may not be worth the effort.

Authors
-------
* Dan Belcher - https://github.com/dbelcher dan@mcneel.com