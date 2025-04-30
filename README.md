# Thomas Harper Computer Science Project



# What is it?
This is the application I made as part of my Computer Science project which helped me get 65/70 - A* equivalent looking at past grade boundaries

It uses WPF for front end, C# for the backend and EF6 + LINQ to access the locally stored "LocalDatabase.mdf" file.

I made this application to allow an imaginary warehouse company "CargoHub" to be able to manage their inventory / stock digitally.

Along with using a database to permanently store the data, I have implemented a binary search tree to mirror the databases. I have done this to experiment with the different kinds of data structures and algorithms which we learnt about in lesson. This means that when a user queries an item, the application traverses through the binary search tree and returns the node if it exists.

# Structure
I thought I'd just explain the structure of the application as it differs from the C++ Imgui application which I made with yourselves.
Files ending in ".xaml" are the front end files while files ending in ".xaml.cs" are the back end files and are found by expanding on the front end files. 

Below is an explanation of the file / folder structure

* Data - This is where I store the binary search tree classes along with the "CurrentUser" class which tells me who's logged into the application
* Images - Used to store images used in the application
* Migrations - Stores the changes made to the local database
* Models - This is the classes which the database is modelled off of
* Views - These are the windows / pages which are used throughout the application. Each view has a respective backend file which is accessed by expanding on the front end file.


# Pre-requisites
In order for this project to be compiled in visual studio you will need the following packages to be installed via the visual studio installer:

* .NET desktop development
* Data storage and processing


# Installation
Pull the "LocalDB" branch from GitHub and run it.


# Usage
Admin Login
* Username: "admin"
* Password: "Password"

Non Admin Login
* Username: "nonAdmin"
* Password: "Password"

Admins can access the admin page to assign tasks whilst non admins cannot.
