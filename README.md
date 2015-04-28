# electro-nigmatron
First go at simulating a German enigma machine using connected nodes to model electric current flow.

The was started during a code dojo kindly organised by Kerry Buckey https://github.com/kerryb for the Suffolk Developers meetup group.

You can see Kerry's description of the Enigma machine problem here: http://kerryb.github.io/enigma/


My implementation of the machine is modeled as a series of disks - each one with nodes around their circumference.  Rotors contain two disks (left and right). while the reflector is a single disk.  The plugboard is also a double disk.  All nodes contain a list of connected nodes.  So calling Electrify() on one should cascade through the system, until the signal again reaches the plugboard and an event is fired which is picked up by the lampboard.

Interestingly - you can call Electrify() on any node inside the machine.  This will cause current to cascade through the machine in two directions - causing the lighboard to light up two letters (the input and output of the machine - or vice versa)
