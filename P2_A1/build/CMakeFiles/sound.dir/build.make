# CMAKE generated file: DO NOT EDIT!
# Generated by "MinGW Makefiles" Generator, CMake Version 3.25

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:

#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:

# Disable VCS-based implicit rules.
% : %,v

# Disable VCS-based implicit rules.
% : RCS/%

# Disable VCS-based implicit rules.
% : RCS/%,v

# Disable VCS-based implicit rules.
% : SCCS/s.%

# Disable VCS-based implicit rules.
% : s.%

.SUFFIXES: .hpux_make_needs_suffix_list

# Command-line flag to silence nested $(MAKE).
$(VERBOSE)MAKESILENT = -s

#Suppress display of executed commands.
$(VERBOSE).SILENT:

# A target that is always out of date.
cmake_force:
.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

SHELL = cmd.exe

# The CMake executable.
CMAKE_COMMAND = C:\Users\di461643\winlibs\winlibs-x86_64-posix-seh-gcc-12.2.0-mingw-w64ucrt-10.0.0-r4\mingw64\bin\cmake.exe

# The command to remove a file.
RM = C:\Users\di461643\winlibs\winlibs-x86_64-posix-seh-gcc-12.2.0-mingw-w64ucrt-10.0.0-r4\mingw64\bin\cmake.exe -E rm -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = C:\Users\di461643\MicroControllTechnik\YAHAL\examples\msp432-launchpad\P2_A1

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = C:\Users\di461643\MicroControllTechnik\YAHAL\examples\msp432-launchpad\P2_A1\build

# Include any dependencies generated for this target.
include CMakeFiles/sound.dir/depend.make
# Include any dependencies generated by the compiler for this target.
include CMakeFiles/sound.dir/compiler_depend.make

# Include the progress variables for this target.
include CMakeFiles/sound.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/sound.dir/flags.make

CMakeFiles/sound.dir/sound.cpp.obj: CMakeFiles/sound.dir/flags.make
CMakeFiles/sound.dir/sound.cpp.obj: C:/Users/di461643/MicroControllTechnik/YAHAL/examples/msp432-launchpad/P2_A1/sound.cpp
CMakeFiles/sound.dir/sound.cpp.obj: CMakeFiles/sound.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=C:\Users\di461643\MicroControllTechnik\YAHAL\examples\msp432-launchpad\P2_A1\build\CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/sound.dir/sound.cpp.obj"
	C:\PROGRA~2\ARMGNU~1\12DBAB~1.2RE\bin\AR10B2~1.EXE $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/sound.dir/sound.cpp.obj -MF CMakeFiles\sound.dir\sound.cpp.obj.d -o CMakeFiles\sound.dir\sound.cpp.obj -c C:\Users\di461643\MicroControllTechnik\YAHAL\examples\msp432-launchpad\P2_A1\sound.cpp

CMakeFiles/sound.dir/sound.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/sound.dir/sound.cpp.i"
	C:\PROGRA~2\ARMGNU~1\12DBAB~1.2RE\bin\AR10B2~1.EXE $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E C:\Users\di461643\MicroControllTechnik\YAHAL\examples\msp432-launchpad\P2_A1\sound.cpp > CMakeFiles\sound.dir\sound.cpp.i

CMakeFiles/sound.dir/sound.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/sound.dir/sound.cpp.s"
	C:\PROGRA~2\ARMGNU~1\12DBAB~1.2RE\bin\AR10B2~1.EXE $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S C:\Users\di461643\MicroControllTechnik\YAHAL\examples\msp432-launchpad\P2_A1\sound.cpp -o CMakeFiles\sound.dir\sound.cpp.s

# Object files for target sound
sound_OBJECTS = \
"CMakeFiles/sound.dir/sound.cpp.obj"

# External object files for target sound
sound_EXTERNAL_OBJECTS =

sound.elf: CMakeFiles/sound.dir/sound.cpp.obj
sound.elf: CMakeFiles/sound.dir/build.make
sound.elf: YAHAL_sound/libYAHAL_sound.a
sound.elf: CMakeFiles/sound.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=C:\Users\di461643\MicroControllTechnik\YAHAL\examples\msp432-launchpad\P2_A1\build\CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX executable sound.elf"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles\sound.dir\link.txt --verbose=$(VERBOSE)
	arm-none-eabi-objcopy -Oihex C:/Users/di461643/MicroControllTechnik/YAHAL/examples/msp432-launchpad/P2_A1/build/sound.elf sound.hex
	arm-none-eabi-objcopy -Obinary C:/Users/di461643/MicroControllTechnik/YAHAL/examples/msp432-launchpad/P2_A1/build/sound.elf sound.bin
	"C:\Program Files (x86)\Arm GNU Toolchain arm-none-eabi\12.2 rel1\bin\arm-none-eabi-objdump.exe" C:/Users/di461643/MicroControllTechnik/YAHAL/examples/msp432-launchpad/P2_A1/build/sound.elf -h > sound.dis
	"C:\Program Files (x86)\Arm GNU Toolchain arm-none-eabi\12.2 rel1\bin\arm-none-eabi-objdump.exe" C:/Users/di461643/MicroControllTechnik/YAHAL/examples/msp432-launchpad/P2_A1/build/sound.elf -d -C >>sound.dis
	C:\Users\di461643\winlibs\winlibs-x86_64-posix-seh-gcc-12.2.0-mingw-w64ucrt-10.0.0-r4\mingw64\bin\cmake.exe -E rename mapfile sound.map

# Rule to build all files generated by this target.
CMakeFiles/sound.dir/build: sound.elf
.PHONY : CMakeFiles/sound.dir/build

CMakeFiles/sound.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles\sound.dir\cmake_clean.cmake
.PHONY : CMakeFiles/sound.dir/clean

CMakeFiles/sound.dir/depend:
	$(CMAKE_COMMAND) -E cmake_depends "MinGW Makefiles" C:\Users\di461643\MicroControllTechnik\YAHAL\examples\msp432-launchpad\P2_A1 C:\Users\di461643\MicroControllTechnik\YAHAL\examples\msp432-launchpad\P2_A1 C:\Users\di461643\MicroControllTechnik\YAHAL\examples\msp432-launchpad\P2_A1\build C:\Users\di461643\MicroControllTechnik\YAHAL\examples\msp432-launchpad\P2_A1\build C:\Users\di461643\MicroControllTechnik\YAHAL\examples\msp432-launchpad\P2_A1\build\CMakeFiles\sound.dir\DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/sound.dir/depend
