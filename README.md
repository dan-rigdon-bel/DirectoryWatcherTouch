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
1.  Clone or download this repository to your Mac running OSX.  Place it in a convenient location such as Development/Repositories/DirectoryWatcherTouch or similar. 
2.  Build the native, static libDirectoryWatcher.a library.  Open a terminal window and navigate to the DirectoryWatcherTouch/DirectoryWatcherNative/DirectoryWatcher folder.  (This folder contains a bash shell script for building the native library for the simulator, armv7 and armv7s.  These three architectures are bundled into single FAT binary using the lipo tool*)  Simply run the following command at the prompt:
    
    sudo ./build_mobile.sh
    
3.  Once the static library has successfully built, you need to point the .NET binding project (DirectoryWatcherTouch) to the correct location.  In Xamarin Studio or Visual Studio, ppen the DirectoryWatcherTouch Solution in the DirectoryWatcherTouch/DirectoryWatcherTouch folder.  The link to libDirectoryWatcher.a will be broken.  Reference this file into the project.
4.  Clean and Build the DirectoryWatcherTouch project.  The resulting DirectoryWatcherTouch.dll that can be referenced into your project.


Usage
----------------------------
Set up a file system watcher...

	// Start watching the Documents folder...
	string documentsFolder = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
	DocumentsDirectoryWatcher = new FileSystemWatcherTouch (documentsFolder);
	DocumentsDirectoryWatcher.Changed += OnDirectoryDidChange;

Handle change event callbacks...

	public void OnDirectoryDidChange (object sender, EventArgs args) {
		Console.WriteLine ("Change detected in the Documents folder");
		// Handle the change...
	}

Detailed Info
----------------------------
The native DirectoryWatcher class comes from this [Apple iOS Developer Library sample](https://developer.apple.com/library/ios/samplecode/DocInteraction/Listings/Classes_DirectoryWatcher_h.html).  This class uses the low-level kqueue kernel event notification system.  The MonoTouch bindings wrapping this small library attempt (in a small way) to mimic Microsoft .NET [FileSystemWatcher](http://msdn.microsoft.com/en-us/library/System.IO.FileSystemWatcher) class, though only the Changed event is current implemented.

* Note on the Static Binary
----------------------------
The build script (build_mobile.sh) included here builds a FAT binary targeting iphonesimulator, armv7, and armv7s.  To make the binary slightly larger for release, you may want to remove the iphonesimulator target.  Regardless, the lipo'd binary is quite small, so it may not be worth the effort.

Authors
-------
* Dan Belcher - https://github.com/dbelcher dan@mcneel.com