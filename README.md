/*	3dpBurner Image2Gcode. A Image to GCODE converter for GRBL based devices.
    This file is part of 3dpBurner mage2Gcode application.
    Copyright (C) 2014-2015  Adrian V. J. (villamany) contact: villamany@gmail.com

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

GitHub notes:
The master branch contain the development version.
Check the "Releases" for release versions and .exe files.

//-------------------------------------------------------
//-------------------- Changelog ------------------------
//-------------------------------------------------------

//-------------------------------------------------------
v0.2
//-------------------------------------------------------
//Some stability issues fixed.

//Added support for 2 and 3 axis laser cutter and 3 axis milling.

//Visual improvments

//Code cleanup

//Added more info about license

//-------------------------------------------------------
v0.1.1
//-------------------------------------------------------
// Improved file streaming speed: On file streaming all line responses was added to log console. this produce a slowly file streaming due many visual lines to move. Now only add lines if response is not "ok"

// Removed "stop" button it no was canceling instantly, now only "start" button enabled/disabled during streaming, press reset if you want to cancel the work.

// Added bufer status text near progress bar

// Added total processed lines on the total lines label

// Other minor changes

v0.1 Initial release