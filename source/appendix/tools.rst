.. index:: development tools

.. _development-tools:

Development Tools 
===============================

The tools requred for this book include the `.NET platform <https://>`_, `VS Code <https://code.visualstudio.com/>`_ , 
and the `C# Dev Kit <https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit>`_ (a 
VS Code extension). In addition, we will also use the ommand Line Interface (CLI) for certain operations
from time to time. 

Software Development Kits (SDKs)
--------------------------------------
A software development kit (SDK) is a collection of software development tools in one installable package. 
They facilitate the creation of applications by having a compiler, debugger and sometimes a software framework. 
They are normally specific to a hardware platform and operating system combination. [#f1]_ The Microsoft .NET 
(".NET Core" before version 5) platform is an open-sourced, cross-platform development platform. 
(The .NET predecessor, ".NET Framework", on the other hand, is is a "proprietary software framework developed by 
Microsoft that runs primarily on Microsoft Windows". [#f2]_) 

Installing Tools
-----------------

#. Install `VS Code <https://code.visualstudio.com/>`_ on your computer. (For package management reasons, 
it is suggested to use a package manager when installing software applications: e.g., `Homebrew <https://brew.sh/>`_ 
for macOS, `Chocolatey <https://chocolatey.org/>`_ for Windows, and apt/snap for Ubuntu Linux.) 

#. Click on the Extensions View on the left vertical Activity Bar of VS Code, search and install, go to the Extension  


Command Line Interface (CLI)
-----------------------------
Having some knowledge of using the command line interface (CLI) is necessary when learning how to code. 
Major platforms such as macOS, Windows, and Linux all have CLIs for users to operate the operating 
system's more advanced features. Users issue text commands in the CLI rather than using the graphical
user interface (GUI) of the operating system. 

The systems have different CLI applications. For example:

* Windows: PowerShell
* macOS: Terminal
* Linux: Terminal/shell 

When you open the CLI application, you are interacting with the computer using the keyboard to issue 
commands rather than poit-and-click devices with the GUI. When you start a CLI, you see a command prompt,
which is where you issue the commands. To start navigating around the CLI environment, some of the 
essential commands include:

* mkdir *dir* (make directory) to create a directory/folder called *dir*
* cd *path* (change directory) to change in the *path* directory in the directory tree structure \(path ".." means the upper level directory).
* ^+C (hold the Control key and then hit the C key) to terminate a process.

As an exercise, you should do the following steps at the CLI to prepare the environment for learning C#:abbr:
# Start your CLI application. By default, you would be in your user home directory. 
# Create a  

<v>




Editing and Building Tools
--------------------------

Early programs were written with rudimentary text editors, 
more primitive than Windows Notepad.  Gradually tools got better.
Now there are editors that are highly optimized for editing code.

After code is edited, it has to be converted into an executable program.
That may involve several files and libraries and other dependencies.
Streamlining and automating this process was a big deal.  There
are a variety of building tools that can be used with, or built into
an SDK:  make, ant, and now NAnt for .net.

Many developers use an a la carte approach, using their favorite editor along
with their favorite building tool.  
 
About Integrated Development Environments (IDE)
-----------------------------------------------

There are also all-in-one tools that combine an editor and build tools.
These are also used by many developers.

There are two major IDEs for .Net development, which we explain briefly below:

- Visual Studio is the Microsoft IDE that interfaces directly to the
  Microsoft SDK.

- Xamarin Studio is the free/open source IDE for developing applications
  using the Mono SDK on Windows and all other platforms (in
  particular, Linux and OS X).  The project started as MonoDevelop.  
  Now Xamarin is both a major contributor to the code and has commercial
  versions for iOS development.  *The name on the software is now*
  **Xamarin Studio**, though you may see references to MonoDevelop instead.

In addition, there is another Windows-specific IDE, SharpDevelop, that
inspired the creation of Xamarin Studio. It is still actively maintained
and provides a somewhat "lighter weight" alternative to Visual Studio
for Windows users. Like Xamarin Studio, it is aimed at developers who
would prefer a more free/open source "friendly" version.

Our Approach
------------

In the interest of providing a consistent experience for our students who use
various operating systems on their own machines,
we will be using the multi-platform Mono (the SDK).

We find the IDE Xamarin Studio convenient to integrate everything for a beginner,
and it is a powerful tool at a more advanced level.  Hence we start off
introducing and using Xamarin Studio.  Later we will look at some of the
underlying tools that are obscured by the use of Xamarin Studio.

Mono has an extra advantage in the tool csharp, for immediate testing of
small snippets of code.  We will use it extensively as we introduce bits of
syntax. 

As there is significant evolution of both the Microsoft
and Mono *toolchains*--a fancy word we want you to know and a more
elegant way of saying SDK--we'll issue updates to this book.

Everything is free, but there are a number of steps.  Follow them carefully.

.. index:: mono installation

.. _install-mono:

Installing Mono and Xamarin Studios
------------------------------------

Because the Mono Project web page is known to change frequently, these
instructions are designed to be as generic as possible. If you have
any questions, you should contact the instructors immediately or seek
tutoring help.


OS X
----

.. warning::
   Xamarin Studio needs at least version 10.8 of OSX.  
   If you have an older version, you can upgrade the operating system, or
   possibly use an older version of Xamarin Studio.  In that case, ask for help.
   
There are two downloads to get and install in order. Mono first:

#. Go to <http://mono-project.com>.

#. Look for the Mono downloads link. Link on OS-X.  
   You want to get the latest *stable*
   version of Mono for OS X. For this class, you need version 2.10 or
   later, though preferably 3.2.4 or later. Choose the MRE version.
   It installs directly. Administrative privileges are required to run the
   installer, so if you do not know this information, please stop
   here.  
   
   Do *not* download Xamarin Studio from this site.  
   This version of Xamararin Studio bugs you with emails.

Here is how to do a quick sanity check of your Mono setup:

#. Go to Applications -> Utilities and launch the Terminal
   application, or quicker: enter terminal in Spotlight. 
   (Terminal is how you get to a command-line shell in OS X.)

#. You'll see a prompt that looks like this 
   ``computername:folder user$``. 
   This means that Terminal is ready for input.

#. Type ``which csharp`` and hit enter/return. You should see
   ``/usr/bin/csharp`` as output. ``csharp`` is the C# interpreter.

#. Type ``which mcs`` and hit enter/return. You should see
   ``/usr/bin/mcs`` as output.  ``mcs`` is one of the interfaces to
   the C# compiler.

.. index:: Xamarin Studio; installation

.. _install-md-osx:

Xamarin Studio Installation - OSX
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

#. Make sure Mono is installed first. 

#. Now go to http://monodevelop.com.  **Note**:  Do *not* use a version
   that is linked to the
   mono-project.com site.  Getting the suggested open-source version
   from http://monodevelop.com should not lead to a prompt for your email address....

#. As with Mono, we need to look for the downloads link. 
   You should download the *stable* version.

#. For OS X, the Xamarin Studio SDK is distributed as a DMG disk image. You'll need
   to download this image and double-click it. Open the image and run
   the installer. Administrative privileges are required to run the
   installer.  

#. This time, you will see an App for Xamarin Studio, 
   which you can drag and drop into the Applications folder.

#. If the preceding steps were successful, you can launch
   Xamarin Studio by double-clicking the icon in your Applications
   folder. (You won't know what to do with it yet, but at least you can
   verify that it launches correctly and then use Command-Q to exit.)

Windows
-------

There are four packages, so this takes a while.  Mono first:

Dr. Yacobellis has a video showing Windows installation.
https://connect.luc.edu/p4hmzk2kbmt/  
There may be further changes to the system.

#. Go to <http://mono-project.com>.

#. Look for the Mono downloads link. You want to get the latest
   *stable* version of Mono for Windows. For this class, you need version
   2.10 or later, preferably 3.2.3 or later.

#. Choose the link: Mono for Windows, Gtk#, and XSP, and download the
   installation package

#. It is a
   self-extracting executable, so you will need to double click it to
   install. For Windows 7 users, you may need to check your taskbar to
   see whether the installer is being held up by Microsoft's enhanced
   security, UAM, that makes sure you really want to install something
   you downloaded from the internet.

Here is how to do a quick sanity check of your Mono setup:

.. index::
   mono command prompt (Windows)
   csharp; mono command prompt (Windows)
   
.. _mono-command-prompt:

Mono Command Prompt
~~~~~~~~~~~~~~~~~~~~

#. Open the Windows Start Menu and type "mono" in the text field at the bottom.  
   You should see a short list of places "mono" appears.
   
#. Click on the choice that says "Mono ... Command prompt".  
   (This is probably faster than going to the Start Menu,
   finding the Mono folder, expanding it, and clicking on
   the Mono Command Prompt.)

If it comes up, you are all set for an initial installation check. This will be the first
step later, when you want to run the handy csharp program or compile and run your
own programs.  When working, you can just leave this window open, 
saving it for later use, 
(or close and reopen later....)  

.. _install-md-win:


Xamarin Studio Installation - Windows
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

#. Have Mono installed first. 
   
#. Now go to http://monodevelop.com.  **Note**:  Do *not* use a version
   that is linked to the
   mono-project.com site.  Getting the suggested open-source version
   from http://monodevelop.com should not lead to a prompt for your email address....

#. As with Mono, we need to look for the downloads link, click on the Windows icon.
   You should
   click the link for the download of the requirements for the *stable* version. 
   That should be at least numbered 4.2.2. **Do not install it yet.**

   **Note however, that you will next**
   **install two support packages**:
   
   * .Net Framework 4.0 first.  The link takes you to a Microsoft download site.
     Do not click the top Download button - that gives you much more than you need.
     Further down in Popular download 01 is 
     Microsoft .NET Framework 4 (Web Installer).  Click on that and follow
     the default sequence.
   
   * GKT#  The GKT@ download directly downloads the GKT installer.  Again follow
     the default installation sequence.
     
   * install Xamarin Studio **last**. The Download link gets you the installer
     directly.  Install it following the default steps.
   
#. If the preceding steps were successful, you can launch
   Xamarin Studio by double-clicking the icon on the Desktop
   or using the Start Menu. 
   (You won't know what to do with it yet, but at least you can
   verify at it launches correctly and then close the window.)

Linux
-----

We only provide instructions for Debian-based Linux distributions such
as Ubuntu.

#. Using the command-line ``apt-get`` tool, you can install everything
   that you need using ``apt-get install monodevelop``. This should be
   run as the **root** user (using the ``sudo`` command).  

#. You can test the sanity of your setup by following the instructions
   under OS X.

Xamarin Studio releases on Linux tend to lag behind the official stable
release. 

This page,
https://launchpad.net/~keks9n/+archive/monodevelop-latest, 
describes
how to update your Xamarin Studio setup if it is not version 2.8 or later
as we'll need for this course.

We wish to stress that Linux is recommended for students who already
have a bit of programming experience under their belts. It can take a
significant amount of energy to get a Linux setup up and running and
to tweak it to your liking. While it has gotten ever so much easier
since the 1990s when it first appeared, we encourage you to set it up
perhaps a bit later in the semester or consider running it using
virtualization software (on Mac or Windows) such as VirtualBox or
VMware.


.. [#f1] Wikipedia Contributors. (2024, July 2). Software development kit. Wikipedia; Wikimedia Foundation. https://en.wikipedia.org/wiki/Software_development_kit
.. [#f2] Wikipedia Contributors. (2024, July 1). .NET Framework. Wikipedia; Wikimedia Foundation. https://en.wikipedia.org/wiki/.NET_Framework

‌
‌